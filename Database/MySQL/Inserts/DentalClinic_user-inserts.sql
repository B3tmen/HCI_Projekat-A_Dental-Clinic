# Adding users
CALL usp_AddDoctor('doctor1', '5624c771a8e2e0c12fb764264e91b321fafaf81178de928864f843bdf194e155', 'Jane', 'Doe', 'jane.doe@mail.com', 1, 'Orthodontics', '123/456-789', 'female', '1500.00');	# pass: sifra1
CALL usp_AddDoctor('doctor2', '5624c771a8e2e0c12fb764264e91b321fafaf81178de928864f843bdf194e155', 'John', 'Doe2', 'john.doe@mail.com', 1, 'Orthodontics', '111/222-333', 'male', '1500.00');	# pass: sifra1

CALL usp_GetUserByUsernameAndPassword('doctor1', '5624c771a8e2e0c12fb764264e91b321fafaf81178de928864f843bdf194e155');


# Adding patients
CALL usp_AddPatient('John', 'Doe', '2002-10-04', 'male', '123/456-789', 'john.doe@mail.com');
CALL usp_AddPatient('Marko', 'Markovic', '2002-10-04', 'male', '065/123-456', 'marko123@gmail.com');
CALL usp_AddPatient('John', 'Doe', '2002-10-04', 'male', '123/456-789', 'john.doe@mail.com');
CALL usp_AddPatient('Marko', 'Markovic', '2002-10-04', 'male', '065/123-456', 'marko123@gmail.com');


CALL usp_AddTheme('Light');
CALL usp_AddTheme('Dark');
CALL usp_AddTheme('Blue');

CALL usp_AddFont('Arial');
CALL usp_AddFont('Calibri');
CALL usp_AddFont('Consolas');
CALL usp_AddFont('Roboto');
CALL usp_AddFont('Times New Roman');
CALL usp_AddFont('Segoe UI');