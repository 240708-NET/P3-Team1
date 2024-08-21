
USE ReevatureOnlineEniversity;


-- TRUNCATE TABLE Courses;
-- TRUNCATE TABLE Professors;
-- TRUNCATE TABLE Sections;
-- TRUNCATE TABLE SectionStudent;
-- TRUNCATE TABLE Students;


INSERT INTO Students ([FirstName],[LastName],[password]) VALUES ('Bobson', 'Dugnut','123');

INSERT INTO Courses ([Name],[Description],[Category]) VALUES ('Intro to Existential Dread','The kids these days love screaming into the void. Why is that? Are they crazy? Yeah, probably. We''re looking into that. We just don''t get it, it''s crazy weird, right?','Humanities');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Esoteric Understandment','Do you not understand things? Do you wake up in the morning and be like "Huh? What?? Who the?? Huh???" Well we can probably help you with that. Like, not all the way, but at least you''ll be able to, like, make toast without staring off into the distance for a really long time and then burning your toast. We''re gonna be investigating stuff like "Why are things the way they are?" and, like, "Do summer blockbusters really matter?" We also do a deep dive into 15-16th century alchemy and how hermetic secret societies contributed directly into the development of the Scientific Revolution. You need to buy your own books, we already ate all our copies.','Humanities');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Boardgame Etiquette and its Geopolitical Fallout','In this course we will be investigating the way in which boardgames have shaped the modern world. Everyone plays boardgames. Like, even rich people, right? It''s wild how many people play boardgames, and they totally influence wars. Also, we will be holding Milton Bradley to account for Monopoly. Torches are included, but you will need to bring your own pitchfork.','Humanities');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Lace Making: A Complete History','This course is a comprehensive investigation on the development of humanity''s greatest artform. Beginning in the 1500''s, we will be tracing the way in which lace making has shaped the development of human dialectics. Needle lace and bobbin lace will be covered simultaneously.','Humanities');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Western Clown Orthodoxy','HONK HONK! Honk honk honk?? HOnk. HONK HONK HONK HONK!!! HOOOOOOOOONK!! Beep beep!!! AWOOGA!! HONK HONK AWOOGA!!! SQUEAK! Womp womp woooomp! HONK!! HONKHONKHONKhonkhonkHOOOONK!!!! HONK HONK!','Humanities');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Human Weaknesses','Yes, we''re all humans here. All of us, we have skin and organs. We respire through gross face tubes and produce sweat from yucky glands. In this course we will be discussing the kinds of weaknesses that human bodies have and how they can be exploited. We will be discussing these weaknesses for normal reasons. Catharsis. That''s a human word, right? Yeah, it''s catharsis. No need to look into this too much. Just come here and describe how you could be taken over don''t worry about it.','Humanities');
INSERT INTO Courses ([name],[description],[category]) VALUES ('TV/VCR Repair','If you can''t pass this course, you''ll never succeed in the business world. Everyone remembers how cool business men were in the 80''s, and it''s cause they loved VCRs. You need to know how to use VCRs or you''re gonna wind up trying to, like, sell bell bottom jeans. Remember bell bottoms? They were really big in the 60''s and 70''s, but then the 80''s came along and buried them underground. The 90''s kept up the trend of cool VCRs, but then they invented DVDs and that''s why the economy is all gunked up. We gotta go back to physical media, guys.','Business');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Insider Trading','Look, it''s not like it''s immoral or anything. Like, who''s even gonna know? People are too worried about stuff like that, when people really should be worried about getting that bag, baybee! Gotta get that dollah, amirite? Like, c''mon man, be cool. If you don''t snitch me out to the cops I''ll let you touch my Bugatti, but you gotta wear gloves cause your hands are probably all greasy and junk. Ew.','Business');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Cheating 101','Everything we teach in here is totally legal. There''s no reason to look into this. Last year someone from the Better Business Bureau came by and asked all sorts of dumb questions like "What do you even teach in this course?" Like, get off my back, right? You''re not my dad! We''re teaching perfectly justifiable things here and it''s fine! You don''t need to look into it. If anyone calls the cops or whatever that''s super uncool and you''re uninvited from the pizza party.','Business');
INSERT INTO Courses ([name],[description],[category]) VALUES ('No Accounting for Taste','Look, some people just like dumb stuff, and like, that''s fine I guess? I once knew a guy who thought that was super cool. He drew all this fan art of Mickey Mouse beating up dragons and stuff. He was pretty good, but it''s like "Why Mickey Mouse?" I dunno. We also teach you how to calculate, like, escrow and stuff.','Business');
INSERT INTO Courses ([name],[description],[category]) VALUES ('The Economics of Copper','People think that the copper trade is super serious. But naw, it''s extremely funny. Like, everyday I get complaints about how bad the copper I sell is and it''s the funniest thing ever! These rubes are like "Dude, my copper broke!" Can you believe it?? It''s absolutely wild. Stick with me and I''ll teach you how to get people to buy copper at any price. I also teach advanced techniques on sorting complaints by comedy level. Seriously, it''s so funny, you''ll love it.','Business');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Cracking Wise','Yeah, yeah, I know what you''re thinking. "I''m plenty funny!" Well let me tell you something, kid. Until you''ve learned the 87 rules of Cracking Wise, you ain''t nothing but a sassy little goblin dancing the Macarena in plaid shorts! Join this class and you''ll be belching the alphabet six ways till Tuesday within a fortnight!','Creative Arts');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Color Theory: What the Heck is Up With It?','Colors don''t make any ding dang sense and I''m tired of pretending like they do. Like, there''s just things that are a different thing from other things cause of their light wavelengths or whatever? That''s nonsense. Utter drek. Join this class and we will overthrow the Illuminatey, the ancient secret society that makes up all the colors. Once we''ve done that we can finally get some peace and quiet.','Creative Arts');
INSERT INTO Courses ([name],[description],[category]) VALUES ('A Cry For Help','Please, I shouldn''t be a teacher. I just woke up here in a tweed jacket one day and everyone was calling me Professor Underside. I can''t remember anything before that. If you think you might know who I am please take this course. Or just come visit me during office hours. Please, I can''t figure out how to get off campus, every time I try to leave I just wind up back in my office.','Creative Arts');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Post Modern Entomology','What even are bugs? We just don''t know. No one has ever been able to answer that question. Not even Sir Harold Bugman III, renowned bug wrangler and oatmeal enthusiast. Sure, some people claim to understand the ins and outs of arthropods, but they''re just pretenders to the throne. No one really knows what a bug is, why it is, or what they want from us. That''s why we have to figure it out, before they figure out what we are.','Natural Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Veterinary Cat Burglary','Look, cats love crime. That''s a fact. Cats love committing crimes and stealing valuable paintings. But cats also get hurt sometimes when they''re stealing expensive jewelry or nuclear launch codes or whatever cats are into these days. And we like cats, no matter how many times they create chaos in the UN by stealing cool jewels from royalty. So we need to know how to bandage up those ouchies. We can''t stop them from committing crimes, they just love crime too much. This is the next best thing.','Natural Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Marriage Apothecary','This course is fully compliant with the rules and regulations set down by the International Wedding Chemist''s Society. Upon completion, you will be legally allowed to prescribe marriage, diagnose relationship maladies, and upcharge newly weds in at least 30 US states.','Natural Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('The Morality of Minerals','Ever wonder which rocks are the most sinful? Sure, we all have. Every morning we wake up and glare suspiciously at the rocks that sit on our bedside table. But how do we know for certain which ones are the most evil? We''re trying to figure that out. We''ve made lots of tests that use all kinds of expensive paper. We''ve also started demanding that the rocks tell us if they''re evil, but they''re pretty quiet and they''d probably lie anyway. Don''t take this course if you''re a rock, we can tell.','Physical Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Infotainment Technology','VVV','Physical Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Cruel & Unusual Chemistry','Chemistry is super hard, you guys. You gotta wear, like, special gloves and goggles and junk, and you gotta use these expensive tubes or whatever. One time I spilled a big cartoon beaker of green stuff all over my feet, and my legs melted and now I have these cool cyborg legs. Like, the legs are awesome, but I miss being able to wear Air Jordans. These robot legs can only wear crocs, it''s super lame. Anyway, chemistry is super dangerous and we''re still trying to figure out how to not melt our legs and whatever. Can you help us?','Physical Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Eldritch Geometry','In this course, we will be investigating shapes which mankind was not meant to understand. We''re gonna look at some super messed up triangles and, like, illegal squares. One of my hexagons is registered as a biohazard by OSHA, but they can''t stop me from showing it to people. My grandpa said that what I was doing was a "sin against rationality" and that "my hubris would be my undoing" but he''s just jealous that I can draw a perfect star and his stars always have one wonky arm and everyone at the Thanksgiving table laughs at him.','Physical Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Martial Tax Evasion: Blackbelt Level','ROE believes very strongly in the importance in instilling its students with a robust understanding of self defense. This course will instill in you enough experience to hold your own on the New York Stock Exchange floor. Lemme tell you, those accountants can throw a mean left hook when the market goes bear. This course makes sure you know how to dodge those punches. No need to look into it further, don''t worry about it.','Business');
INSERT INTO Courses ([name],[description],[category]) VALUES ('Underwater Macrame','Remember the 70''s? Disco was all the rage, there definitely wasn''t any political or social upheaval, and indoor decor was at its all time brownest. Ruling over that brownness was macrame, the one true artform. But the greatest weakness of macrame was that you couldn''t do it underwater. Well we aim to change that. Please bring snorkels.','Creative Arts');

INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VVV','Physical Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VvVV','Physical Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VVV','Natural Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VVV','Creative Arts');
INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VVVv','Creative Arts');
INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VVV','Natural Science');
INSERT INTO Courses ([name],[description],[category]) VALUES ('VVV','VVV','Natural Science');


INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Crudelia','Onswitch','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Ogden','Allthetime','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Bewilderforce','Underside','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Samantha','Bevelhead','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Norman','Humanman','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Merci','Marquis','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Sleve','McBichael','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Grandma','Dustice','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Melma','Trukstuff','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Dwight','Rortugal','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Squedge','Sernandez','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Todd','Bonzalez','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Won''tber','Whateley','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Richard','Hawkins','123');
INSERT INTO Professors ([FirstName],[LastName],[password]) VALUES ('Ulada','Haranina','123');



---- BOBSON'S SECTIONS
-- MON
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (7,1,'08:00:00','10:00:00','Mon'); --- Crudelia Onswitch teaching TV/VCR Repair
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (20,2,'10:00:00','12:00:00','Mon'); --- Ogden Allthetime teaching Cruel and Unusual Chemistry
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (16,14,'14:00:00','16:00:00','Mon'); --- Richard teaching Cat Burg


-- TUE
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (3,10,'08:00:00','10:00:00','Tue'); --- Dwight Rortugal teaching Boardgame Etiquette
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (4,8,'10:00:00','12:00:00','Tue'); --- Grandma Dustice teaching Lace Making
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (19,9,'15:00:00','17:00:00','Tue'); --- Melma Trukstuff teaching Infotainment Technology


-- WED
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (12,7,'08:00:00','10:00:00','Wed'); --- Sleve McBichael teaching Cracking Wise
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (13,11,'10:00:00','12:00:00','Wed'); --- Squedge Sernandez teaching Color Theory
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (21,13,'14:00:00','16:00:00','Wed'); --- Whateley teaching Eldritch Geometry


-- THU
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (2,15,'08:00:00','10:00:00','Thu'); --- Ulada teaching Esoteric Understandment
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (14,3,'10:00:00','12:00:00','Thu'); --- Bewilderforce teaching A Cry for Help
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (18,4,'14:00:00','16:00:00','Thu'); --- Samantha Bevelhead teaching the Morality of Minerals


-- FRI
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (5,6,'08:00:00','10:00:00','Fri'); --- Merci Marquis teaching Western Clown Orthodoxy
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (6,5,'10:00:00','12:00:00','Fri'); --- Norman Humanman teaching Human Weaknesses
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (17,12,'15:00:00','17:00:00','Fri'); --- Todd Bonzalez teaching Marriage Apothecary




--- MON 8-10

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (23,1,'08:00:00','10:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (12,2,'08:00:00','10:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (4,3,'08:00:00','10:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (5,4,'08:00:00','10:00:00','Mon');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (7,1,'08:00:00','10:00:00','Mon'); --- Crudelia Onswitch teaching TV/VCR Repair

--- MON 10-12

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (10,6,'10:00:00','12:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (7,7,'10:00:00','12:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (8,8,'10:00:00','12:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (9,9,'10:00:00','12:00:00','Mon');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (20,2,'10:00:00','12:00:00','Mon'); --- Ogden Allthetime teaching Cruel and Unusual Chemistry

--- MON 14-16

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (21,12,'14:00:00','16:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (17,11,'14:00:00','16:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (15,13,'14:00:00','16:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (13,15,'14:00:00','16:00:00','Mon');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (16,14,'14:00:00','16:00:00','Mon'); --- Richard teaching Cat Burg


--- MON 15-17

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (1,6,'15:00:00','17:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (2,4,'15:00:00','17:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (3,5,'15:00:00','17:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (6,10,'15:00:00','17:00:00','Mon');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (10,1,'15:00:00','17:00:00','Mon');






--- TUE 8-10

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (5,4,'08:00:00','10:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (6,5,'08:00:00','10:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (7,6,'08:00:00','10:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (8,7,'08:00:00','10:00:00','Tue');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (3,10,'08:00:00','10:00:00','Tue'); --- Dwight Rortugal teaching Boardgame Etiquette


--- TUE 10-12

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (9,1,'10:00:00','12:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (10,3,'10:00:00','12:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (11,2,'10:00:00','12:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (12,14,'10:00:00','12:00:00','Tue');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (4,8,'10:00:00','12:00:00','Tue'); --- Grandma Dustice teaching Lace Making

--- TUE 14-16

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (13,10,'14:00:00','16:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (14,11,'14:00:00','16:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (15,12,'14:00:00','16:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (16,13,'14:00:00','16:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (17,14,'14:00:00','16:00:00','Tue');

--- TUE 15-17

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (18,15,'15:00:00','17:00:00','Tue');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (19,9,'15:00:00','17:00:00','Tue'); --- Melma Trukstuff teaching Infotainment Technology
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (20,1,'15:00:00','17:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (1,2,'15:00:00','17:00:00','Tue');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (2,3,'15:00:00','17:00:00','Tue');





--- WED 8-10

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (5,2,'08:00:00','10:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (6,3,'08:00:00','10:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (7,4,'08:00:00','10:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (8,5,'08:00:00','10:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (9,6,'08:00:00','10:00:00','Wed');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (12,7,'08:00:00','10:00:00','Wed'); --- Sleve McBichael teaching Cracking Wise

--- WED 10-12

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (10,1,'10:00:00','12:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (11,15,'10:00:00','12:00:00','Wed');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (13,11,'10:00:00','12:00:00','Wed'); --- Squedge Sernandez teaching Color Theory
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (14,8,'10:00:00','12:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (15,9,'10:00:00','12:00:00','Wed');

--- WED 14-16

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (16,10,'14:00:00','16:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (17,10,'14:00:00','16:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (18,14,'14:00:00','16:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (19,15,'14:00:00','16:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (20,1,'14:00:00','16:00:00','Wed');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (21,13,'14:00:00','16:00:00','Wed'); --- Whateley teaching Eldritch Geometry

--- WED 15-17

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (23,6,'15:00:00','17:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (1,3,'15:00:00','17:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (2,9,'15:00:00','17:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (3,6,'15:00:00','17:00:00','Wed');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (4,2,'15:00:00','17:00:00','Wed');






--- THU 8-10

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (21,5,'08:00:00','10:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (22,6,'08:00:00','10:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (23,7,'08:00:00','10:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (1,8,'08:00:00','10:00:00','Thu');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (2,15,'08:00:00','10:00:00','Thu'); --- Ulada teaching Esoteric Understandment

--- THU 10-12

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (6,9,'10:00:00','12:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (7,10,'10:00:00','12:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (8,11,'10:00:00','12:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (9,12,'10:00:00','12:00:00','Thu');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (14,3,'10:00:00','12:00:00','Thu'); --- Bewilderforce teaching A Cry for Help

--- THU 14-16

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (11,14,'14:00:00','16:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (12,1,'14:00:00','16:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (13,2,'14:00:00','16:00:00','Thu');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (18,4,'14:00:00','16:00:00','Thu'); --- Samantha Bevelhead teaching the Morality of Minerals
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (15,9,'14:00:00','16:00:00','Thu');

--- THU 15-17

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (16,7,'15:00:00','17:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (17,12,'15:00:00','17:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (18,11,'15:00:00','17:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (19,6,'15:00:00','17:00:00','Thu');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (20,5,'15:00:00','17:00:00','Thu');






--- FRI 8-10

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (1,12,'08:00:00','10:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (2,13,'08:00:00','10:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (3,14,'08:00:00','10:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (4,15,'08:00:00','10:00:00','Fri');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (5,6,'08:00:00','10:00:00','Fri'); --- Merci Marquis teaching Western Clown Orthodoxy

--- FRI 10-12

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (10,1,'10:00:00','12:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (11,2,'10:00:00','12:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (12,3,'10:00:00','12:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (13,4,'10:00:00','12:00:00','Fri');
-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (6,5,'10:00:00','12:00:00','Fri'); --- Norman Humanman teaching Human Weaknesses

--- FRI 14-16

INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (14,13,'14:00:00','16:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (15,12,'14:00:00','16:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (16,14,'14:00:00','16:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (18,6,'14:00:00','16:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (19,7,'14:00:00','16:00:00','Fri');

--- FRI 15-17

-- INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (17,12,'15:00:00','17:00:00','Fri'); --- Todd Bonzalez teaching Marriage Apothecary
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (20,8,'15:00:00','17:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (21,9,'15:00:00','17:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (22,10,'15:00:00','17:00:00','Fri');
INSERT INTO Sections ([CourseID],[ProfessorID],[StartTime],[EndTime],[Day]) VALUES (23,11,'15:00:00','17:00:00','Fri');





--- Bobson's Sections
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (6,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (7,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (8,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (9,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (10,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (11,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (12,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (13,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (14,1);
INSERT INTO SectionStudent ([SectionsID],[StudentsID]) VALUES (15,1);

