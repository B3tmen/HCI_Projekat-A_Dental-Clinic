
# --- Adding an appointment
DELIMITER $$
CREATE PROCEDURE usp_AddAppointment(
	IN p_fk_patient_id INT,
    IN p_fk_doctor_id INT,
    IN p_date_time DATETIME,
    IN p_fk_appointment_status_id INT
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
    END;

	START TRANSACTION;
		INSERT INTO `appointment` (fk_patient_id, fk_doctor_id, date_time, fk_appointment_status_id)
        VALUES (p_fk_patient_id, p_fk_doctor_id, p_date_time, p_fk_appointment_status_id);
	COMMIT;
END $$
DELIMITER ;

# --- Adding appointment_status
DELIMITER $$
CREATE PROCEDURE usp_AddAppointmentStatus(
	IN p_status ENUM('confirmed', 'missed', 'cancelled', 'finished')
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
    END;

	START TRANSACTION;
		INSERT INTO `appointment_status` (status)
        VALUES (p_status);
	COMMIT;
END $$
DELIMITER ;