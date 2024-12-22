# --- Doctors view
CREATE VIEW vw_doctors AS
SELECT
	d.fk_user_id AS doctor_id, u.username, u.password_hash, u.first_name, u.last_name, u.email, u.is_active, 
    d.specialization, d.phone_number, d.gender, d.salary, up.fk_language_id, up.fk_theme_id, up.fk_font_id
FROM doctor d
INNER JOIN user u ON d.fk_user_id = u.user_id 	# or just JOIN...
LEFT JOIN user_preferences up ON d.fk_user_id = up.fk_user_id
WHERE u.role = 'doctor';

# --- All users view
CREATE VIEW vw_all_users AS
SELECT	u.user_id, u.username, u.password_hash, u.first_name, u.last_name, u.email, u.role, u.is_active, up.fk_language_id, up.fk_theme_id, up.fk_font_id,
		d.phone_number, d.specialization, d.gender, d.salary
FROM user u
LEFT JOIN doctor d ON u.user_id = d.fk_user_id
LEFT JOIN user_preferences up ON u.user_id = up.fk_user_id;

# --- Appointments view
CREATE VIEW vw_appointments AS
SELECT
	a.appointment_id AS appointment_id,
    p.patient_id AS patient_id,
    CONCAT(u.first_name, ' ', u.last_name) AS doctor_name,
    p.first_name AS first_name,
    p.last_name AS last_name,
    p.date_of_birth AS date_of_birth,
    p.gender AS gender,
    p.phone_number AS phone_number,
    p.email AS email,
    a.date_time AS reservation_time,
    appStat.status AS status
FROM appointment a
JOIN patient p ON a.fk_patient_id = p.patient_id
JOIN appointment_status appStat ON a.fk_appointment_status_id = appStat.status_id
JOIN user u ON a.fk_doctor_id = u.user_id;

# --- Receipt details view
CREATE VIEW vw_receipt_details AS
SELECT
	r.receipt_id AS receipt_id,
    r.fk_patient_id AS patient_id,
    r.date_issued AS date_issued,
	t.name AS treatment_name,
    t.price AS price,
    ri.quantity AS number_of_treated_teeth,
    (ri.sub_total) AS subtotal
FROM treatment t
JOIN receipt_item ri ON ri.fk_treatment_id = t.treatment_id
JOIN receipt r ON r.receipt_id = ri.fk_receipt_id;