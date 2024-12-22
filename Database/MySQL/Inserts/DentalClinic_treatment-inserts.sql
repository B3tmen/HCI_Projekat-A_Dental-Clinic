#ALTER TABLE `medicine` AUTO_INCREMENT = 1;

CALL usp_AddMedicine('Paracetamol', 7, 3, '2027-10-04');
CALL usp_AddMedicine('Antibiotic', 10, 3, '2028-12-31');