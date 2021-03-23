-- NOTESPACE DATABASE SETUP --
-- Wes Miller
-- 14 Feb 2021

DROP DATABASE IF EXISTS NOTESPACE;
CREATE DATABASE NOTESPACE;

USE NOTESPACE;

CREATE TABLE NotespaceUser (
	UserID INT IDENTITY(1, 1) PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	LastLogon DATETIME
);

CREATE TABLE NotespaceNotebook (
	NotebookID INT IDENTITY PRIMARY KEY,
	UserID INT FOREIGN KEY REFERENCES NotespaceUser(UserID),
	NotebookName VARCHAR(50) NOT NULL,
	PubliclyAvailable BIT NOT NULL,
	NotebookColor INT NOT NULL,
	LastModified DATETIME
);

CREATE TABLE NotespaceNote (
	NoteID INT IDENTITY PRIMARY KEY,
	UserID INT FOREIGN KEY REFERENCES NotespaceUser(UserID),
	NotebookID INT FOREIGN KEY REFERENCES NotespaceNotebook(NotebookID),
	NoteName VARCHAR(50) NOT NULL,
	PubliclyAvailable BIT NOT NULL,
	Plaintext VARCHAR(MAX),
	ConvertedHTML VARCHAR(MAX),
	LastModified DATETIME
);

insert into NotespaceUser (Username, Password, Email, LastLogon) values ('lbotte0', 'it4fzpW7cx', 'rsussans0@t-online.de', '3/23/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('aforshaw1', 'rwHMP21ebcU', 'gfrude1@bluehost.com', '10/22/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('arennels2', 'jZlcWBTgax4', 'vcranham2@fda.gov', '8/28/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('otafani3', 'pFufTvnwvr6d', 'adryburgh3@bluehost.com', '10/11/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('elauderdale4', '3n5UCy2y', 'spoppleton4@deliciousdays.com', '12/13/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('rcopperwaite5', '2maiD9T', 'dchirm5@1und1.de', '10/10/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('nforkan6', '74bkO2D', 'mbeacham6@lycos.com', '8/3/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('amacfayden7', 'q7VRWF', 'tsvanini7@hp.com', '12/2/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('hjennens8', 'JFLqCJ6b', 'wduncanson8@indiegogo.com', '4/19/2020');
insert into NotespaceUser (Username, Password, Email, LastLogon) values ('markwright9', 'ujVJQXohd5MY', 'edabling9@oracle.com', '9/12/2020');

insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (7, 'Seventh Continent, The (Der siebente Kontinent)', 0, 3, '11/14/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (10, 'Casino Royale', 1, 4, '5/4/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (6, 'My Girlfriend''s Boyfriend', 0, 5, '11/25/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (9, 'Noah''s Ark', 0, 5, '11/28/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (7, 'Soldier''s Story, A', 0, 4, '9/29/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (3, 'Escape to Athena', 0, 4, '7/10/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (1, 'Jeanne and the Perfect Guy (Jeanne et le garçon formidable)', 0, 1, '5/1/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (4, 'Branded to Kill (Koroshi no rakuin)', 1, 1, '3/16/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (2, 'Rosemary''s Baby', 0, 5, '12/19/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (1, 'Japanese Story', 1, 1, '6/6/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (5, 'Louis C.K.: Live at the Beacon Theater', 0, 3, '4/14/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (9, 'Accidental Spy, The (Dak miu mai shing)', 0, 4, '9/9/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (5, 'Terror''s Advocate (Avocat de la terreur, L'')', 1, 2, '11/6/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (9, 'Night in the Life of Jimmy Reardon, A', 1, 2, '1/4/2021');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (6, 'Figures in a Landscape', 0, 1, '8/16/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (9, 'Border Run (Mule, The)', 0, 3, '9/26/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (5, 'Dylan Moran: Like, Totally', 0, 2, '8/19/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (2, 'Fire Down Below', 0, 1, '3/23/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (6, 'Big City Blues', 1, 2, '3/11/2020');
insert into NotespaceNotebook (UserID, NotebookName, PubliclyAvailable, NotebookColor, LastModified) values (1, 'Music Box, The', 1, 5, '11/4/2020');

insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (1, null, 'Trou, Le (Hole, The) (Night Watch, The)', 1, 'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.

Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.

Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.

Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.', null, '6/23/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (2, 6, 'First Family', 1, 'Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.

Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.

Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.

Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', null, '10/2/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (10, null, 'White Hell of Pitz Palu, The (Die weiße Hölle vom Piz Palü) ', 1, 'Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.

In congue. Etiam justo. Etiam pretium iaculis justo.

In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.

Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.

Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.', null, '8/16/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (1, null, 'Memorial Day', 1, 'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.

Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.

Phasellus in felis. Donec semper sapien a libero. Nam dui.

Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.

Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.', null, '4/28/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (3, 17, 'Danger: Diabolik (Diabolik)', 0, 'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.

Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.

In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.

Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo. Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui.', null, '3/14/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (9, 9, 'Captives', 1, 'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.

Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.

In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet.', null, '4/7/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (1, null, 'Starry starry night (Xing kong)', 1, 'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.

Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.

Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.

Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.

Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.', null, '6/10/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (1, null, 'Jauja', 1, 'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.

Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.

Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.

In congue. Etiam justo. Etiam pretium iaculis justo.

In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', null, '10/22/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (2, 12, 'I Am the Law', 0, 'Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.

Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.

In congue. Etiam justo. Etiam pretium iaculis justo.

In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', null, '3/11/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (8, 13, 'Legend of the Eight Samurai (Satomi hakken-den)', 0, 'Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti.

Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.

Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.

Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.', null, '1/11/2021');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (10, null, 'Dead Fish', 1, 'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.

Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.

Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', null, '11/8/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (3, null, 'Wondrous Oblivion', 0, 'Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.

Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.

In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.

Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.', null, '3/1/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (7, null, 'Little Children', 0, 'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.

Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.

Proin interdum mauris non ligula pellentesque ultrices. Phasellus id sapien in sapien iaculis congue. Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl.

Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.

Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est.', null, '6/9/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (5, null, 'How I Unleashed World War II (Jak rozpetalem II wojne swiatowa)', 0, 'Sed ante. Vivamus tortor. Duis mattis egestas metus.

Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.

Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.

Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.

In congue. Etiam justo. Etiam pretium iaculis justo.', null, '8/7/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (7, 12, 'Beijing Bicycle (Shiqi sui de dan che)', 1, 'In congue. Etiam justo. Etiam pretium iaculis justo.

In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.

Nulla ut erat id mauris vulputate elementum. Nullam varius. Nulla facilisi.

Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.', null, '9/4/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (6, 4, 'Four Weddings and a Funeral', 1, 'Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.

Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.

Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.

Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.

Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', null, '9/4/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (3, null, 'Play it to the Bone', 1, 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.

Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.

Pellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.

Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.', null, '11/2/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (10, null, 'The Legend of Awesomest Maximus', 0, 'Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.

Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.

Fusce consequat. Nulla nisl. Nunc nisl.

Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.', null, '9/28/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (4, 12, 'Butterflies Have No Memories', 1, 'Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.

In sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.

Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.

Maecenas ut massa quis augue luctus tincidunt. Nulla mollis molestie lorem. Quisque ut erat.

Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.', null, '5/30/2020');
insert into NotespaceNote (UserID, NotebookID, NoteName, PubliclyAvailable, Plaintext, ConvertedHTML, LastModified) values (4, 9, 'Joy Division', 1, 'Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.

Quisque id justo sit amet sapien dignissim vestibulum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros.

Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue. Aliquam erat volutpat.

In congue. Etiam justo. Etiam pretium iaculis justo.

In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.', null, '8/5/2020');


SELECT * FROM NotespaceUser;
SELECT * FROM NotespaceNote;
SELECT * FROM NotespaceNotebook;