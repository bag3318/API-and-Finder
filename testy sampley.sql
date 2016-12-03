/*https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-stored-procedures.html*/
DELIMITER //
CREATE PROCEDURE delete_message
(IN con CHAR(20))
BEGIN
  SELECT Name, HeadOfState FROM Country
  WHERE Continent = con;
END //
DELIMITER ;