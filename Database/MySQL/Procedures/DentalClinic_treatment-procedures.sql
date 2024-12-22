# =================================== MEDICINE ==========================================
# --- Add medicine
DELIMITER $$
CREATE PROCEDURE usp_AddMedicine(IN p_name VARCHAR(45), IN p_days_of_use INT, IN p_use_times_per_day INT, IN p_expiration_date DATE)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
    END;
    
    START TRANSACTION;
		INSERT INTO `medicine` (name, days_of_use, use_times_per_day, expiration_date)
		VALUES (p_name, p_days_of_use, p_use_times_per_day, p_expiration_date);
    COMMIT;
END $$
DELIMITER ;

# --- Update medicine
DELIMITER $$
CREATE PROCEDURE usp_UpdateMedicine(IN p_medicine_id INT, IN p_name VARCHAR(45), IN p_days_of_use INT, IN p_use_times_per_day INT, IN p_expiration_date DATE, IN p_is_usable BOOLEAN)
BEGIN
	UPDATE medicine
    SET
		name = p_name,
        days_of_use = p_days_of_use,
        use_times_per_day = p_use_times_per_day,
        expiration_date = p_expiration_date,
        is_usable = p_is_usable
    WHERE medicine_id = p_medicine_id;
END $$
DELIMITER ;
# =================================== TREATMENT ==========================================
DELIMITER $$
CREATE PROCEDURE usp_AddTreatment(IN p_name VARCHAR(45), IN p_description TEXT(2000), IN p_price DECIMAL(6, 2), IN p_fk_medicine_id INT, IN p_treated_teeth JSON)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
    END;
    
    START TRANSACTION;
		INSERT INTO `treatment` (name, description, price, fk_medicine_id, treated_teeth)
		VALUES (p_name, p_description, p_price, p_fk_medicine_id, p_treated_teeth);
    COMMIT;
    
    SELECT LAST_INSERT_ID();
END $$
DELIMITER ;