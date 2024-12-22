# --- Adding a receipt
DELIMITER $$
CREATE PROCEDURE usp_AddReceipt(IN p_fk_patient_id INT, IN p_date_issued DATETIME, IN p_grand_total DECIMAL (6,2))
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
	END;

    START TRANSACTION;
		INSERT INTO `receipt` (fk_patient_id, date_issued, grand_total) 
		VALUES (p_fk_patient_id, p_date_issued, p_grand_total);
    COMMIT;
    
    SELECT LAST_INSERT_ID();
END $$
DELIMITER ;


# --- Adding receipt item
DELIMITER $$
CREATE PROCEDURE usp_AddReceiptItem(
	IN p_fk_receipt_id INT,
    IN p_fk_treatment_id INT,
    IN p_price DECIMAL(6, 2),
    IN p_quantity INT
)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		SHOW ERRORS;
        ROLLBACK;
	END;
    
    START TRANSACTION;    
		INSERT INTO `receipt_item`(fk_receipt_id, fk_treatment_id, price, quantity)
		VALUES (p_fk_receipt_id, p_fk_treatment_id, p_price, p_quantity);
    COMMIT;
END $$
DELIMITER ;