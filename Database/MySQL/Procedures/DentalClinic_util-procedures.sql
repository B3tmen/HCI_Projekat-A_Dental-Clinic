# ===================================== DASHBOARD UTILITIES =====================================
DELIMITER $$
CREATE PROCEDURE usp_GetTodayAppointmentsCount(IN p_doctor_id INT)
BEGIN
    SELECT COUNT(*) AS today_appointments
    FROM appointment
    WHERE 
        date_time >= CURDATE()
        AND date_time < CURDATE() + INTERVAL 1 DAY
        AND fk_doctor_id = p_doctor_id;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_GetActiveDoctorsCount()
BEGIN
	SELECT COUNT(*) AS active_doctors_count
    FROM doctor d
    JOIN user u ON d.fk_user_id = u.user_id
    WHERE u.is_active = 1;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_GetFinishedAppointmentsCount()
BEGIN
	SELECT COUNT(*) AS finished_appointments
    FROM appointment a
    WHERE a.fk_appointment_status_id = 4;  # finished appointment status id = 4
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_GetCancelledAppointmentsCount()
BEGIN
	SELECT COUNT(*) AS cancelled_appointments
    FROM appointment a
    WHERE a.fk_appointment_status_id = 3;  # cancelled appointment status id = 3
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_GetLastReceiptId()
BEGIN
	SELECT MAX(receipt_id) AS last_receipt_id FROM receipt; 	# receipt_id is autonumber
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE usp_GetLastAppointmentId()
BEGIN
	SELECT MAX(appointment_id) AS last_appointment_id FROM appointment;
END $$
DELIMITER ;

