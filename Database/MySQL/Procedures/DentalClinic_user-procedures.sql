# ======================================================== ADD/CREATE PROCEDURES ==========================================================
# --- Adding user
DELIMITER $$
CREATE PROCEDURE usp_AddUser(
	IN p_username VARCHAR(45),
    IN p_password_hash VARCHAR(128),
    IN p_first_name VARCHAR(45),
    IN p_last_name VARCHAR(45),
    IN p_email VARCHAR(100),
    IN p_role ENUM('doctor', 'administrator'),
    IN p_is_active TINYINT(1)
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
	END;
    
    START TRANSACTION;
	
    INSERT INTO `user` (username, password_hash, first_name, last_name, email, role, is_active)
    VALUES (p_username, p_password_hash, p_first_name, p_last_name, p_email, p_role, p_is_active);
    
    COMMIT;
    SELECT @user_id;

END $$
DELIMITER ;


# --- Adding doctor
DELIMITER $$
CREATE PROCEDURE usp_AddDoctor(
	IN p_username VARCHAR(45),
    IN p_password_hash VARCHAR(128),
    IN p_first_name VARCHAR(45),
    IN p_last_name VARCHAR(45),
    IN p_email VARCHAR(100),
    IN p_is_active TINYINT(1),
	IN p_specialization VARCHAR(45),
    IN p_phone_number VARCHAR(45),
    IN p_gender ENUM('male', 'female'),
    IN p_salary DECIMAL(6, 2)
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
	END;
    
	START TRANSACTION;
	
	-- First inserting into the 'user' table
    CALL usp_AddUser(p_username, p_password_hash, p_first_name, p_last_name, p_email, 'doctor', p_is_active);
    SET @doctor_id = LAST_INSERT_ID();
    
    -- Then inserting the doctor record
    INSERT INTO `doctor` (fk_user_id, specialization, phone_number, gender, salary) 
    VALUES (@doctor_id, p_specialization, p_phone_number, p_gender, p_salary);
    
    COMMIT;
    
    SELECT @doctor_id;
END $$
DELIMITER ;


# --- Adding Administrator
DELIMITER $$
CREATE PROCEDURE usp_AddAdministrator(
    IN p_username VARCHAR(45),
    IN p_password_hash VARCHAR(128),
    IN p_first_name VARCHAR(45),
    IN p_last_name VARCHAR(45),
    IN p_email VARCHAR(100),
    IN p_is_active TINYINT(1)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
	END;

    START TRANSACTION;

    -- Call the AddUser procedure to add the user
    CALL usp_AddUser(p_username, p_password_hash, p_first_name, p_last_name, p_email, 'administrator', p_is_active);
	SET @admin_id = LAST_INSERT_ID();

    -- Inserting the administrator record
    INSERT INTO `administrator` (fk_user_id) 
    VALUES (@admin_id);

    COMMIT;
    
    SELECT @admin_id;
END $$
DELIMITER ;


# --- Adding Patient
DELIMITER $$
CREATE PROCEDURE usp_AddPatient(
	IN p_first_name VARCHAR(45), 
    IN p_last_name VARCHAR(45), 
    IN p_date_of_birth DATE, 
    IN p_gender ENUM('male', 'female'), 
    IN p_phone_number VARCHAR(45),
    IN p_email VARCHAR(45)
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
    END;
    
    START TRANSACTION;
		INSERT INTO `patient` (first_name, last_name, date_of_birth, gender, phone_number, email)
        VALUES (p_first_name, p_last_name, p_date_of_birth, p_gender, p_phone_number, p_email);
    COMMIT;
END $$
DELIMITER ;

# --- Adding language
DELIMITER $$
CREATE PROCEDURE usp_AddLanguage(IN p_name VARCHAR(30))
BEGIN
	DECLARE language_exists INT DEFAULT 0;
    
    -- EXIT HANDLER for exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SHOW ERRORS;
    END;

    -- Check if the language already exists
    SELECT COUNT(*) INTO language_exists
    FROM `user_language` WHERE `name` = p_name;

    IF language_exists > 0 THEN
        -- Language already exists
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Language already exists.';
    ELSE
        -- Language does not exist, proceed with the insertion
        START TRANSACTION;
            INSERT INTO `user_language` (name) VALUES (p_name);
        COMMIT;
    END IF;
END $$
DELIMITER ;


# --- Adding theme
DELIMITER $$
CREATE PROCEDURE usp_AddTheme(IN p_name VARCHAR(30))
BEGIN
	DECLARE theme_exists INT DEFAULT 0;

    -- EXIT HANDLER for exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SHOW ERRORS;
    END;

    -- Check if the language already exists
    SELECT COUNT(*) INTO theme_exists
    FROM `user_theme` WHERE `name` = p_name;

    IF theme_exists > 0 THEN
        -- Theme already exists
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Theme already exists.';
    ELSE
        -- Theme does not exist, proceed with the insertion
        START TRANSACTION;
            INSERT INTO `user_theme` (name) VALUES (p_name);
        COMMIT;
    END IF;
END $$
DELIMITER ;

# --- Adding fonts
DELIMITER $$
CREATE PROCEDURE usp_AddFont(IN p_name VARCHAR(30))
BEGIN
	DECLARE font_exists INT DEFAULT 0;

    -- EXIT HANDLER for exceptions
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SHOW ERRORS;
    END;

    -- Check if the language already exists
    SELECT COUNT(*) INTO font_exists
    FROM `user_font` WHERE `name` = p_name;

    IF font_exists > 0 THEN
        -- Font already exists
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Font already exists.';
    ELSE
        -- Font does not exist, proceed with the insertion
        START TRANSACTION;
            INSERT INTO `user_font` (name) VALUES (p_name);
        COMMIT;
    END IF;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_AddUserPreference(IN p_fk_user_id INT, IN p_fk_language_id INT, IN p_fk_theme_id INT, IN p_fk_font_id INT)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
		SHOW ERRORS;
    END;
    
    START TRANSACTION;
		INSERT INTO user_preferences (fk_user_id, fk_language_id, fk_theme_id, fk_font_id)
		VALUES(p_fk_user_id, p_fk_language_id, p_fk_theme_id, p_fk_font_id);
    COMMIT;
END $$
DELIMITER ;


# ======================================================== GET/RETRIEVE PROCEDURES ==========================================================
# --- Get a doctor by ID
DELIMITER $$
CREATE PROCEDURE usp_GetDoctorById(IN p_doctor_id INT)
BEGIN
	SELECT u.user_id, u.username, u.password_hash, u.first_name, u.last_name, u.is_active, 
		d.specialization, d.phone_number, d.gender, d.salary
	FROM `user` u
    INNER JOIN doctor d ON u.user_id = d.fk_user_id;
END $$
DELIMITER ;

# --- Get an admin by ID
DELIMITER $$
CREATE PROCEDURE usp_GetAdministratorById(IN p_doctor_id INT)
BEGIN
	SELECT u.user_id, u.username, u.password_hash, u.first_name, u.last_name, u.is_active
	FROM `user` u
    INNER JOIN administrator a ON u.user_id = a.fk_user_id;
END $$
DELIMITER ;

# --- Get a patient by ID
DELIMITER $$
CREATE PROCEDURE usp_GetPatientById(IN p_patient_id INT)
BEGIN
	SELECT patient_id, first_name, last_name, date_of_birth, gender, phone_number, email
	FROM `patient` WHERE patient_id = p_patient_id;
END $$
DELIMITER ;

# --- Get a user by username and pass
DELIMITER $$
CREATE PROCEDURE usp_GetUserByUsernameAndPassword(IN p_username VARCHAR(45), IN p_password_hash VARCHAR(128))
BEGIN
	SELECT u.user_id, u.username, u.password_hash, u.first_name, u.last_name, u.email, u.role, u.is_active, 
        CASE 
            WHEN u.role = 'doctor' THEN d.specialization
            ELSE NULL 
        END AS specialization,
        CASE 
            WHEN u.role = 'doctor' THEN d.phone_number
            ELSE NULL 
        END AS phone_number,
        CASE 
            WHEN u.role = 'doctor' THEN d.gender
            ELSE NULL 
        END AS gender,
        CASE 
            WHEN u.role = 'doctor' THEN d.salary
            ELSE NULL 
        END AS salary,
		up.fk_language_id, up.fk_theme_id, up.fk_font_id
    FROM user u
    LEFT JOIN doctor d ON u.user_id = d.fk_user_id
    LEFT JOIN user_preferences up ON u.user_id = up.fk_user_id
    WHERE u.username = p_username AND u.password_hash = p_password_hash;
END $$	
DELIMITER ;

# --- Get a language by ID
DELIMITER $$
CREATE PROCEDURE usp_GetLanguageById(IN p_language_id INT)
BEGIN
	SELECT language_id, name
	FROM `user_language` WHERE language_id = p_language_id;
END $$
DELIMITER ;

# --- Get a theme by ID
DELIMITER $$
CREATE PROCEDURE usp_GetThemeById(IN p_theme_id INT)
BEGIN
	SELECT theme_id, name
	FROM `user_theme` WHERE theme_id = p_theme_id;
END $$
DELIMITER ;

# --- Get a font by ID
DELIMITER $$
CREATE PROCEDURE usp_GetFontById(IN p_font_id INT)
BEGIN
	SELECT font_id, name
	FROM `user_font` WHERE font_id = p_font_id;
END $$
DELIMITER ;

# ======================================================== UPDATE PROCEDURES ==========================================================
# --- Updating a User
DELIMITER $$
CREATE PROCEDURE usp_UpdateUser(
	IN p_user_id INT,
	IN p_username VARCHAR(45), 
    IN p_password_hash VARCHAR(128), 
    IN p_first_name VARCHAR(45), 
    IN p_last_name VARCHAR(45),  
    IN p_email VARCHAR(100),
    IN p_is_active TINYINT(1)
)
BEGIN
	UPDATE user 
    SET
		username = p_username,
        password_hash = p_password_hash,
        first_name = p_first_name,
        last_name = p_last_name,
        email = p_email,
        is_active = p_is_active
	WHERE user_id = p_user_id;
END $$
DELIMITER ;

# --- Updating a Doctor
DELIMITER $$
CREATE PROCEDURE usp_UpdateDoctor(
	IN p_user_id INT,
	IN p_username VARCHAR(45), 
    IN p_password_hash VARCHAR(128), 
    IN p_first_name VARCHAR(45), 
    IN p_last_name VARCHAR(45),  
    IN p_email VARCHAR(100),
    IN p_is_active TINYINT(1),
    IN p_specialization VARCHAR(45),
    IN p_phone_number VARCHAR(45),
    IN p_gender ENUM('male', 'female'),
    IN p_salary DECIMAL(6, 2)
)
BEGIN
	CALL usp_UpdateUser(p_user_id, p_username, p_password_hash, p_first_name, p_last_name, p_email, p_is_active);
    
    UPDATE doctor
    SET
		specialization = p_specialization,
        phone_number = p_phone_number,
        gender = p_gender,
        salary = p_salary
    WHERE fk_user_id = p_user_id;
END $$
DELIMITER ;

# --- Updating a users preffered language
DELIMITER $$
CREATE PROCEDURE usp_UpdateUserLanguage(IN p_user_id INT, IN p_language_id INT)
BEGIN
	DECLARE user_exists BOOLEAN DEFAULT FALSE;
    SELECT EXISTS (SELECT 1 FROM user_preferences WHERE fk_user_id = p_user_id) INTO user_exists;
    
    IF user_exists THEN
		UPDATE user_preferences
		SET
			fk_language_id = p_language_id
		WHERE fk_user_id = p_user_id;
    ELSE
		START TRANSACTION;
			INSERT INTO user_preferences (fk_user_id, fk_language_id)
			VALUES(p_user_id, p_language_id);
		COMMIT;
    END IF;
END $$
DELIMITER ;

# --- Updating a users preffered theme
DELIMITER $$
CREATE PROCEDURE usp_UpdateUserTheme(IN p_user_id INT, IN p_theme_id INT)
BEGIN
	DECLARE user_exists BOOLEAN DEFAULT FALSE;
    SELECT EXISTS (SELECT 1 FROM user_preferences WHERE fk_user_id = p_user_id) INTO user_exists;
    
    IF user_exists THEN
		UPDATE user_preferences
		SET
			fk_theme_id = p_theme_id
		WHERE fk_user_id = p_user_id;
    ELSE
		START TRANSACTION;
			INSERT INTO user_preferences (fk_user_id, fk_theme_id)
			VALUES(p_user_id, p_theme_id);
		COMMIT;
    END IF;
END $$
DELIMITER ;

# --- Updating a users preffered font
DELIMITER $$
CREATE PROCEDURE usp_UpdateUserFont(IN p_user_id INT, IN p_font_id INT)
BEGIN
	DECLARE user_exists BOOLEAN DEFAULT FALSE;
    SELECT EXISTS (SELECT 1 FROM user_preferences WHERE fk_user_id = p_user_id) INTO user_exists;
    
    IF user_exists THEN
		UPDATE user_preferences
		SET
			fk_font_id = p_font_id
		WHERE fk_user_id = p_user_id;
    ELSE
		START TRANSACTION;
			INSERT INTO user_preferences (fk_user_id, fk_font_id)
			VALUES(p_user_id, p_font_id);
		COMMIT;
    END IF;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_UpdateUserPreference(IN p_fk_user_id INT, IN p_fk_language_id INT, IN p_fk_theme_id INT, IN p_fk_font_id INT)
BEGIN
	UPDATE user_preferences
    SET
		fk_language_id = p_fk_language_id,
        fk_theme_id = p_fk_theme_id,
        fk_font_id = p_fk_font_id
    WHERE fk_user_id = p_fk_user_id;
END $$
DELIMITER ;
