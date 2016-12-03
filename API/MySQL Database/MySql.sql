/*********************************************************************************************************

* Purpose: The following code will create the database and three tables,
* it will then insert data into the three master data tables
*
* Create date: 11/30/16
* Created by: BGLATMAN
*
* Version	 	Date		Author			Comment
*--------------------------------------------------------------------------------------------------------
*    1		  11/30/16	   BGLATMAN		Initial version
*
********************************************************************************************************/

CREATE DATABASE `finder` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci */; /* create database: finder */

CREATE TABLE `message` ( /* create table: message */
    `id`         int    (11)                           NOT NULL, /* create column id that can be up to 11 digits and is an integer, and cannot be null*/
    `rating`     int    (11)                           NOT NULL,
    `usrmessage` varchar(888) CHARACTER SET latin1 DEFAULT NULL, /* type variable character (888 = maximum number of characters) */
     PRIMARY KEY     (`id`)
)    ENGINE = InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci; /* define character set: latin1 (basically english), collate: latin1_general: english */


CREATE TABLE `months` (
    `id`         int    (11) NOT NULL AUTO_INCREMENT,
    `month`      varchar(10) COLLATE latin1_general_ci NOT NULL,
    `birthstone` varchar(10) COLLATE latin1_general_ci NOT NULL,
    `days`       varchar(45) COLLATE latin1_general_ci NOT NULL,
     PRIMARY KEY        (`id`)
)    ENGINE = InnoDB AUTO_INCREMENT = 13 DEFAULT CHARSET = latin1 COLLATE = latin1_general_ci;

CREATE TABLE `zodiac_sign` (
    `id` int        (11)                           NOT NULL AUTO_INCREMENT,
    `zodiac` varchar(10) COLLATE latin1_general_ci NOT NULL,
     PRIMARY KEY    (`id`)
)    ENGINE = InnoDB AUTO_INCREMENT = 13 DEFAULT CHARSET = latin1 COLLATE = latin1_general_ci;

INSERT INTO message (rating, usrmessage) VALUES (6, "Great Web API; however, you must finish it.");
INSERT INTO message (rating, usrmessage) VALUES (1, "Bob is a loser"                             );

UPDATE `finder`.`message`
SET
`id` = 2,
`rating` = 4,
`message` = "Fun Fact: Freddy Mercury's real name is actually Freddy Bulsara (that was before he changed his last name)."
WHERE `id` = 2;



INSERT INTO months (month, birthstone, days) VALUES ('January'  , 'Garnet'    , 31); /* insert into the table months; with the format (month, birthstone, days), the values: ('January', 'Garnet', 31); */
INSERT INTO months (month, birthstone, days) VALUES ('February' , 'Amethyst'  , 29);
INSERT INTO months (month, birthstone, days) VALUES ('March'    , 'Aquamarine', 31);
INSERT INTO months (month, birthstone, days) VALUES ('April'    , 'Diamond'   , 30);
INSERT INTO months (month, birthstone, days) VALUES ('May'      , 'Emerald'   , 31);
INSERT INTO months (month, birthstone, days) VALUES ('June'     , 'Pearl'     , 30);
INSERT INTO months (month, birthstone, days) VALUES ('July'     , 'Ruby'      , 31);
INSERT INTO months (month, birthstone, days) VALUES ('August'   , 'Peridot'   , 31);
INSERT INTO months (month, birthstone, days) VALUES ('September', 'Sapphire'  , 30);
INSERT INTO months (month, birthstone, days) VALUES ('October'  , 'Opal'      , 31);
INSERT INTO months (month, birthstone, days) VALUES ('November' , 'Topaz'     , 30);
INSERT INTO months (month, birthstone, days) VALUES ('December' , 'Turqoise'  , 31);


INSERT INTO zodiac_sign (zodiac) VALUES ( "Capricorn" );
INSERT INTO zodiac_sign (zodiac) VALUES (  "Aquarius" );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Pisces"  );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Aries"   );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Taurus"  );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Gemini"  );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Cancer"  );
INSERT INTO zodiac_sign (zodiac) VALUES (    "Leo"    );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Virgo"   );
INSERT INTO zodiac_sign (zodiac) VALUES (   "Libra"   );
INSERT INTO zodiac_sign (zodiac) VALUES (  "Scorpio"  );
INSERT INTO zodiac_sign (zodiac) VALUES ("Sagittarius");
