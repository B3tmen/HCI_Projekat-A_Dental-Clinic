# --- Updating the grand total of a receipt
DELIMITER $$
CREATE TRIGGER trig_UpdateReceiptGrandTotal_after_insert
AFTER INSERT ON receipt_item
FOR EACH ROW
BEGIN
	-- Updating the grand total of a receipt
    UPDATE `receipt`
    SET grand_total = (
        SELECT SUM(sub_total) FROM receipt_item
        WHERE fk_receipt_id = NEW.fk_receipt_id
    )
    WHERE receipt_id = NEW.fk_receipt_id;
END $$
DELIMITER ;