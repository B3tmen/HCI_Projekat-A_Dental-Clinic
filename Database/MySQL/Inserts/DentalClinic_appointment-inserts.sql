CALL usp_AddAppointmentStatus('confirmed');
CALL usp_AddAppointmentStatus('missed');
CALL usp_AddAppointmentStatus('cancelled');
CALL usp_AddAppointmentStatus('finished');

CALL usp_AddAppointment(1, 1, '2024-11-08 09:30:00', 1);
CALL usp_AddAppointment(1, 1, '2024-11-14 09:30:00', 1);

#ALTER TABLE treatment AUTO_INCREMENT = 1;