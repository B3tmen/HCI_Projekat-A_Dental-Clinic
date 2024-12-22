-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema db_dental-clinic
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema db_dental-clinic
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `db_dental-clinic` DEFAULT CHARACTER SET utf8 ;
USE `db_dental-clinic` ;

-- -----------------------------------------------------
-- Table `db_dental-clinic`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`user` (
  `user_id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password_hash` VARCHAR(128) NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `role` ENUM('doctor', 'administrator') NOT NULL,
  `is_active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE,
  UNIQUE INDEX `user_id_UNIQUE` (`user_id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`doctor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`doctor` (
  `fk_user_id` INT NOT NULL,
  `specialization` VARCHAR(45) NOT NULL,
  `phone_number` VARCHAR(45) NOT NULL,
  `gender` ENUM('MALE', 'FEMALE') NOT NULL,
  `salary` DECIMAL(6,2) NOT NULL,
  PRIMARY KEY (`fk_user_id`),
  CONSTRAINT `fk_doctor_user`
    FOREIGN KEY (`fk_user_id`)
    REFERENCES `db_dental-clinic`.`user` (`user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`administrator`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`administrator` (
  `fk_user_id` INT NOT NULL,
  PRIMARY KEY (`fk_user_id`),
  CONSTRAINT `fk_administrator_user1`
    FOREIGN KEY (`fk_user_id`)
    REFERENCES `db_dental-clinic`.`user` (`user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`patient`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`patient` (
  `patient_id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `date_of_birth` DATE NOT NULL,
  `gender` ENUM('MALE', 'FEMALE') NOT NULL,
  `phone_number` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`patient_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`appointment_status`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`appointment_status` (
  `status_id` INT NOT NULL AUTO_INCREMENT,
  `status` ENUM('confirmed', 'missed', 'cancelled', 'finished') NULL,
  PRIMARY KEY (`status_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`appointment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`appointment` (
  `appointment_id` INT NOT NULL AUTO_INCREMENT,
  `fk_patient_id` INT NOT NULL,
  `fk_doctor_id` INT NOT NULL,
  `date_time` DATETIME NOT NULL,
  `fk_appointment_status_id` INT NOT NULL,
  PRIMARY KEY (`appointment_id`),
  INDEX `fk_appointment_patient1_idx` (`fk_patient_id` ASC) VISIBLE,
  INDEX `fk_appointment_doctor1_idx` (`fk_doctor_id` ASC) VISIBLE,
  INDEX `fk_appointment_appointment_status1_idx` (`fk_appointment_status_id` ASC) VISIBLE,
  CONSTRAINT `fk_appointment_patient1`
    FOREIGN KEY (`fk_patient_id`)
    REFERENCES `db_dental-clinic`.`patient` (`patient_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_appointment_doctor1`
    FOREIGN KEY (`fk_doctor_id`)
    REFERENCES `db_dental-clinic`.`doctor` (`fk_user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_appointment_appointment_status1`
    FOREIGN KEY (`fk_appointment_status_id`)
    REFERENCES `db_dental-clinic`.`appointment_status` (`status_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`receipt`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`receipt` (
  `receipt_id` INT NOT NULL AUTO_INCREMENT,
  `fk_patient_id` INT NULL,
  `grand_total` DECIMAL(6,2) NULL,
  `date_issued` DATETIME NOT NULL,
  PRIMARY KEY (`receipt_id`),
  INDEX `fk_receipt_patient1_idx` (`fk_patient_id` ASC) VISIBLE,
  CONSTRAINT `fk_receipt_patient1`
    FOREIGN KEY (`fk_patient_id`)
    REFERENCES `db_dental-clinic`.`patient` (`patient_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`medicine`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`medicine` (
  `medicine_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `days_of_use` INT NOT NULL,
  `use_times_per_day` INT NOT NULL,
  `expiration_date` DATE NOT NULL,
  `is_usable` TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (`medicine_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`treatment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`treatment` (
  `treatment_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `description` TEXT(2000) NOT NULL,
  `price` DECIMAL(6,2) NOT NULL,
  `fk_medicine_id` INT NOT NULL,
  `treated_teeth` JSON NOT NULL,
  PRIMARY KEY (`treatment_id`),
  INDEX `fk_treatment_medicine1_idx` (`fk_medicine_id` ASC) VISIBLE,
  CONSTRAINT `fk_treatment_medicine1`
    FOREIGN KEY (`fk_medicine_id`)
    REFERENCES `db_dental-clinic`.`medicine` (`medicine_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`receipt_item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`receipt_item` (
  `fk_receipt_id` INT NOT NULL,
  `fk_treatment_id` INT NOT NULL,
  `price` DECIMAL(6,2) NOT NULL,
  `quantity` INT NULL,
  `sub_total` DECIMAL(6,2) NULL DEFAULT (price*quantity),
  PRIMARY KEY (`fk_receipt_id`, `fk_treatment_id`),
  INDEX `fk_receipt_item_treatment1_idx` (`fk_treatment_id` ASC) VISIBLE,
  CONSTRAINT `fk_receipt_item_receipt1`
    FOREIGN KEY (`fk_receipt_id`)
    REFERENCES `db_dental-clinic`.`receipt` (`receipt_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_receipt_item_treatment1`
    FOREIGN KEY (`fk_treatment_id`)
    REFERENCES `db_dental-clinic`.`treatment` (`treatment_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`user_theme`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`user_theme` (
  `theme_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`theme_id`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`user_language`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`user_language` (
  `language_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`language_id`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`user_font`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`user_font` (
  `font_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`font_id`),
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `db_dental-clinic`.`user_preferences`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dental-clinic`.`user_preferences` (
  `fk_user_id` INT NOT NULL,
  `fk_language_id` INT NULL,
  `fk_theme_id` INT NULL,
  `fk_font_id` INT NULL,
  PRIMARY KEY (`fk_user_id`),
  INDEX `fk_user_preferences_user_language1_idx` (`fk_language_id` ASC) VISIBLE,
  INDEX `fk_user_preferences_user_theme1_idx` (`fk_theme_id` ASC) VISIBLE,
  INDEX `fk_user_preferences_user_font1_idx` (`fk_font_id` ASC) VISIBLE,
  CONSTRAINT `fk_user_preferences_user1`
    FOREIGN KEY (`fk_user_id`)
    REFERENCES `db_dental-clinic`.`user` (`user_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_preferences_user_language1`
    FOREIGN KEY (`fk_language_id`)
    REFERENCES `db_dental-clinic`.`user_language` (`language_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_preferences_user_theme1`
    FOREIGN KEY (`fk_theme_id`)
    REFERENCES `db_dental-clinic`.`user_theme` (`theme_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_preferences_user_font1`
    FOREIGN KEY (`fk_font_id`)
    REFERENCES `db_dental-clinic`.`user_font` (`font_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
