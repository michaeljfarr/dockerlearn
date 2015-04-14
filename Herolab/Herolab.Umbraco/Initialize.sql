-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: mysql.local    Database: umbracodb
-- ------------------------------------------------------
-- Server version	5.5.5-10.0.17-MariaDB-1~wheezy-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `cmscontent`
--

LOCK TABLES `cmscontent` WRITE;
/*!40000 ALTER TABLE `cmscontent` DISABLE KEYS */;
INSERT INTO `cmscontent` VALUES (1,1048,1047),(2,1049,1032);
/*!40000 ALTER TABLE `cmscontent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmscontenttype`
--

LOCK TABLES `cmscontenttype` WRITE;
/*!40000 ALTER TABLE `cmscontenttype` DISABLE KEYS */;
INSERT INTO `cmscontenttype` VALUES (531,1044,'Member','icon-user','icon-user',NULL,0,0),(532,1031,'Folder','icon-folder','icon-folder',NULL,0,1),(533,1032,'Image','icon-picture','icon-picture',NULL,0,0),(534,1033,'File','icon-document','icon-document',NULL,0,0),(535,1047,'Home','.sprTreeFolder','folder.png','',0,0);
/*!40000 ALTER TABLE `cmscontenttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmscontenttype2contenttype`
--

LOCK TABLES `cmscontenttype2contenttype` WRITE;
/*!40000 ALTER TABLE `cmscontenttype2contenttype` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmscontenttype2contenttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmscontenttypeallowedcontenttype`
--

LOCK TABLES `cmscontenttypeallowedcontenttype` WRITE;
/*!40000 ALTER TABLE `cmscontenttypeallowedcontenttype` DISABLE KEYS */;
INSERT INTO `cmscontenttypeallowedcontenttype` VALUES (1031,1031,0),(1031,1032,0),(1031,1033,0);
/*!40000 ALTER TABLE `cmscontenttypeallowedcontenttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmscontentversion`
--

LOCK TABLES `cmscontentversion` WRITE;
/*!40000 ALTER TABLE `cmscontentversion` DISABLE KEYS */;
INSERT INTO `cmscontentversion` VALUES (1,1048,'cecf78c2-2d78-4ed2-bc38-0eea407be3a2','2015-04-13 08:28:50',NULL),(2,1048,'dd6df784-0d0a-4408-92d0-29c872fb2a16','2015-04-13 08:29:14',NULL),(3,1049,'2c6126e5-dffc-4860-81bd-92d9bdd73df6','2015-04-13 08:31:29',NULL),(4,1048,'bdb6845f-9be7-4bbf-8dd6-6bf22a4fc07d','2015-04-13 08:31:48',NULL);
/*!40000 ALTER TABLE `cmscontentversion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmscontentxml`
--

LOCK TABLES `cmscontentxml` WRITE;
/*!40000 ALTER TABLE `cmscontentxml` DISABLE KEYS */;
INSERT INTO `cmscontentxml` VALUES (1048,'<Home id=\"1048\" parentID=\"-1\" level=\"1\" creatorID=\"0\" sortOrder=\"0\" createDate=\"2015-04-13T08:28:50\" updateDate=\"2015-04-13T08:31:48\" nodeName=\"Home\" urlName=\"home\" path=\"-1,1048\" isDoc=\"\" nodeType=\"1047\" creatorName=\"Michael Farr\" writerName=\"Michael Farr\" writerID=\"0\" template=\"1046\" nodeTypeAlias=\"Home\">\r\n  <testvalue1><![CDATA[TestVal1]]></testvalue1>\r\n  <testvalue2><![CDATA[TestVal2]]></testvalue2>\r\n  <mediaexample>1049</mediaexample>\r\n</Home>'),(1049,'<Image id=\"1049\" parentID=\"-1\" level=\"1\" creatorID=\"0\" sortOrder=\"0\" createDate=\"2015-04-13T08:31:29\" updateDate=\"2015-04-13T08:31:29\" nodeName=\"SPLDOLPHIN_380x254.jpg\" urlName=\"spldolphin_380x254jpg\" path=\"-1,1049\" isDoc=\"\" nodeType=\"1032\" writerName=\"Michael Farr\" writerID=\"0\" version=\"2c6126e5-dffc-4860-81bd-92d9bdd73df6\" template=\"0\" nodeTypeAlias=\"Image\">\r\n  <umbracoFile><![CDATA[/media/1002/spldolphin_380x254.jpg]]></umbracoFile>\r\n  <umbracoWidth><![CDATA[380]]></umbracoWidth>\r\n  <umbracoHeight><![CDATA[254]]></umbracoHeight>\r\n  <umbracoBytes><![CDATA[52911]]></umbracoBytes>\r\n  <umbracoExtension><![CDATA[jpg]]></umbracoExtension>\r\n</Image>');
/*!40000 ALTER TABLE `cmscontentxml` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsdatatype`
--

LOCK TABLES `cmsdatatype` WRITE;
/*!40000 ALTER TABLE `cmsdatatype` DISABLE KEYS */;
INSERT INTO `cmsdatatype` VALUES (-28,-97,'Umbraco.ListView','Nvarchar'),(-27,-96,'Umbraco.ListView','Nvarchar'),(-26,-95,'Umbraco.ListView','Nvarchar'),(1,-49,'Umbraco.TrueFalse','Integer'),(2,-51,'Umbraco.Integer','Integer'),(3,-87,'Umbraco.TinyMCEv3','Ntext'),(4,-88,'Umbraco.Textbox','Nvarchar'),(5,-89,'Umbraco.TextboxMultiple','Ntext'),(6,-90,'Umbraco.UploadField','Nvarchar'),(7,-92,'Umbraco.NoEdit','Nvarchar'),(8,-36,'Umbraco.DateTime','Date'),(9,-37,'Umbraco.ColorPickerAlias','Nvarchar'),(10,-38,'Umbraco.FolderBrowser','Nvarchar'),(11,-39,'Umbraco.DropDownMultiple','Nvarchar'),(12,-40,'Umbraco.RadioButtonList','Nvarchar'),(13,-41,'Umbraco.Date','Date'),(14,-42,'Umbraco.DropDown','Integer'),(15,-43,'Umbraco.CheckBoxList','Nvarchar'),(16,1034,'Umbraco.ContentPickerAlias','Integer'),(17,1035,'Umbraco.MediaPicker','Integer'),(18,1036,'Umbraco.MemberPicker','Integer'),(21,1040,'Umbraco.RelatedLinks','Ntext'),(22,1041,'Umbraco.Tags','Ntext'),(24,1043,'Umbraco.ImageCropper','Ntext'),(25,1045,'Umbraco.MultipleMediaPicker','Nvarchar');
/*!40000 ALTER TABLE `cmsdatatype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsdatatypeprevalues`
--

LOCK TABLES `cmsdatatypeprevalues` WRITE;
/*!40000 ALTER TABLE `cmsdatatypeprevalues` DISABLE KEYS */;
INSERT INTO `cmsdatatypeprevalues` VALUES (-4,-97,'[{\"alias\":\"email\",\"isSystem\":1},{\"alias\":\"username\",\"isSystem\":1},{\"alias\":\"updateDate\",\"header\":\"Last edited\",\"isSystem\":1}]',4,'includeProperties'),(-3,-97,'asc',3,'orderDirection'),(-2,-97,'Name',2,'orderBy'),(-1,-97,'10',1,'pageSize'),(3,-87,',code,undo,redo,cut,copy,mcepasteword,stylepicker,bold,italic,bullist,numlist,outdent,indent,mcelink,unlink,mceinsertanchor,mceimage,umbracomacro,mceinserttable,umbracoembed,mcecharmap,|1|1,2,3,|0|500,400|1049,|true|',0,''),(4,1041,'default',0,'group'),(5,1045,'1',0,'multiPicker');
/*!40000 ALTER TABLE `cmsdatatypeprevalues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsdictionary`
--

LOCK TABLES `cmsdictionary` WRITE;
/*!40000 ALTER TABLE `cmsdictionary` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsdictionary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsdocument`
--

LOCK TABLES `cmsdocument` WRITE;
/*!40000 ALTER TABLE `cmsdocument` DISABLE KEYS */;
INSERT INTO `cmsdocument` VALUES (1048,1,0,'bdb6845f-9be7-4bbf-8dd6-6bf22a4fc07d','Home',NULL,NULL,'2015-04-13 08:31:48',1046,1),(1048,0,0,'cecf78c2-2d78-4ed2-bc38-0eea407be3a2','Home',NULL,NULL,'2015-04-13 08:28:50',1046,0),(1048,0,0,'dd6df784-0d0a-4408-92d0-29c872fb2a16','Home',NULL,NULL,'2015-04-13 08:29:14',1046,0);
/*!40000 ALTER TABLE `cmsdocument` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsdocumenttype`
--

LOCK TABLES `cmsdocumenttype` WRITE;
/*!40000 ALTER TABLE `cmsdocumenttype` DISABLE KEYS */;
INSERT INTO `cmsdocumenttype` VALUES (1047,1046,1);
/*!40000 ALTER TABLE `cmsdocumenttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmslanguagetext`
--

LOCK TABLES `cmslanguagetext` WRITE;
/*!40000 ALTER TABLE `cmslanguagetext` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmslanguagetext` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsmacro`
--

LOCK TABLES `cmsmacro` WRITE;
/*!40000 ALTER TABLE `cmsmacro` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsmacro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsmacroproperty`
--

LOCK TABLES `cmsmacroproperty` WRITE;
/*!40000 ALTER TABLE `cmsmacroproperty` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsmacroproperty` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsmember`
--

LOCK TABLES `cmsmember` WRITE;
/*!40000 ALTER TABLE `cmsmember` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsmember` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsmember2membergroup`
--

LOCK TABLES `cmsmember2membergroup` WRITE;
/*!40000 ALTER TABLE `cmsmember2membergroup` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsmember2membergroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsmembertype`
--

LOCK TABLES `cmsmembertype` WRITE;
/*!40000 ALTER TABLE `cmsmembertype` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsmembertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmspreviewxml`
--

LOCK TABLES `cmspreviewxml` WRITE;
/*!40000 ALTER TABLE `cmspreviewxml` DISABLE KEYS */;
INSERT INTO `cmspreviewxml` VALUES (1048,'bdb6845f-9be7-4bbf-8dd6-6bf22a4fc07d','2015-04-13 08:31:48','<Home id=\"1048\" parentID=\"-1\" level=\"1\" creatorID=\"0\" sortOrder=\"0\" createDate=\"2015-04-13T08:28:50\" updateDate=\"2015-04-13T08:31:48\" nodeName=\"Home\" urlName=\"home\" path=\"-1,1048\" isDoc=\"\" nodeType=\"1047\" creatorName=\"Michael Farr\" writerName=\"Michael Farr\" writerID=\"0\" template=\"1046\" nodeTypeAlias=\"Home\">\r\n  <testvalue1><![CDATA[TestVal1]]></testvalue1>\r\n  <testvalue2><![CDATA[TestVal2]]></testvalue2>\r\n  <mediaexample>1049</mediaexample>\r\n</Home>'),(1048,'cecf78c2-2d78-4ed2-bc38-0eea407be3a2','2015-04-13 08:28:50','<Home id=\"1048\" parentID=\"-1\" level=\"1\" creatorID=\"0\" sortOrder=\"0\" createDate=\"2015-04-13T08:28:50\" updateDate=\"2015-04-13T08:28:50\" nodeName=\"Home\" urlName=\"home\" path=\"-1,1048\" isDoc=\"\" nodeType=\"1047\" creatorName=\"Michael Farr\" writerName=\"Michael Farr\" writerID=\"0\" template=\"1046\" nodeTypeAlias=\"Home\" />'),(1048,'dd6df784-0d0a-4408-92d0-29c872fb2a16','2015-04-13 08:29:15','<Home id=\"1048\" parentID=\"-1\" level=\"1\" creatorID=\"0\" sortOrder=\"0\" createDate=\"2015-04-13T08:28:50\" updateDate=\"2015-04-13T08:29:14\" nodeName=\"Home\" urlName=\"home\" path=\"-1,1048\" isDoc=\"\" nodeType=\"1047\" creatorName=\"Michael Farr\" writerName=\"Michael Farr\" writerID=\"0\" template=\"1046\" nodeTypeAlias=\"Home\">\r\n  <testvalue1><![CDATA[TestVal1]]></testvalue1>\r\n  <testvalue2><![CDATA[TestVal2]]></testvalue2>\r\n</Home>');
/*!40000 ALTER TABLE `cmspreviewxml` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmspropertydata`
--

LOCK TABLES `cmspropertydata` WRITE;
/*!40000 ALTER TABLE `cmspropertydata` DISABLE KEYS */;
INSERT INTO `cmspropertydata` VALUES (1,1048,'cecf78c2-2d78-4ed2-bc38-0eea407be3a2',35,NULL,NULL,NULL,NULL),(2,1048,'cecf78c2-2d78-4ed2-bc38-0eea407be3a2',36,NULL,NULL,NULL,NULL),(3,1048,'cecf78c2-2d78-4ed2-bc38-0eea407be3a2',37,NULL,NULL,NULL,NULL),(4,1048,'dd6df784-0d0a-4408-92d0-29c872fb2a16',35,NULL,NULL,'TestVal1',NULL),(5,1048,'dd6df784-0d0a-4408-92d0-29c872fb2a16',36,NULL,NULL,'TestVal2',NULL),(6,1048,'dd6df784-0d0a-4408-92d0-29c872fb2a16',37,NULL,NULL,NULL,NULL),(7,1049,'2c6126e5-dffc-4860-81bd-92d9bdd73df6',6,NULL,NULL,'/media/1002/spldolphin_380x254.jpg',NULL),(8,1049,'2c6126e5-dffc-4860-81bd-92d9bdd73df6',7,NULL,NULL,'380',NULL),(9,1049,'2c6126e5-dffc-4860-81bd-92d9bdd73df6',8,NULL,NULL,'254',NULL),(10,1049,'2c6126e5-dffc-4860-81bd-92d9bdd73df6',9,NULL,NULL,'52911',NULL),(11,1049,'2c6126e5-dffc-4860-81bd-92d9bdd73df6',10,NULL,NULL,'jpg',NULL),(12,1048,'bdb6845f-9be7-4bbf-8dd6-6bf22a4fc07d',35,NULL,NULL,'TestVal1',NULL),(13,1048,'bdb6845f-9be7-4bbf-8dd6-6bf22a4fc07d',36,NULL,NULL,'TestVal2',NULL),(14,1048,'bdb6845f-9be7-4bbf-8dd6-6bf22a4fc07d',37,1049,NULL,NULL,NULL);
/*!40000 ALTER TABLE `cmspropertydata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmspropertytype`
--

LOCK TABLES `cmspropertytype` WRITE;
/*!40000 ALTER TABLE `cmspropertytype` DISABLE KEYS */;
INSERT INTO `cmspropertytype` VALUES (6,-90,1032,3,'umbracoFile','Upload image',NULL,0,0,NULL,NULL),(7,-92,1032,3,'umbracoWidth','Width',NULL,0,0,NULL,NULL),(8,-92,1032,3,'umbracoHeight','Height',NULL,0,0,NULL,NULL),(9,-92,1032,3,'umbracoBytes','Size',NULL,0,0,NULL,NULL),(10,-92,1032,3,'umbracoExtension','Type',NULL,0,0,NULL,NULL),(24,-90,1033,4,'umbracoFile','Upload file',NULL,0,0,NULL,NULL),(25,-92,1033,4,'umbracoExtension','Type',NULL,0,0,NULL,NULL),(26,-92,1033,4,'umbracoBytes','Size',NULL,0,0,NULL,NULL),(27,-38,1031,5,'contents','Contents:',NULL,0,0,NULL,NULL),(28,-89,1044,11,'umbracoMemberComments','Comments',NULL,0,0,NULL,NULL),(29,-92,1044,11,'umbracoMemberFailedPasswordAttempts','Failed Password Attempts',NULL,1,0,NULL,NULL),(30,-49,1044,11,'umbracoMemberApproved','Is Approved',NULL,2,0,NULL,NULL),(31,-49,1044,11,'umbracoMemberLockedOut','Is Locked Out',NULL,3,0,NULL,NULL),(32,-92,1044,11,'umbracoMemberLastLockoutDate','Last Lockout Date',NULL,4,0,NULL,NULL),(33,-92,1044,11,'umbracoMemberLastLogin','Last Login Date',NULL,5,0,NULL,NULL),(34,-92,1044,11,'umbracoMemberLastPasswordChangeDate','Last Password Change Date',NULL,6,0,NULL,NULL),(35,-88,1047,NULL,'testvalue1','TestValue1',NULL,0,0,'',''),(36,-88,1047,NULL,'testvalue2','TestValue2',NULL,1,0,'',''),(37,1035,1047,NULL,'mediaexample','MediaExample',NULL,2,0,'','');
/*!40000 ALTER TABLE `cmspropertytype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmspropertytypegroup`
--

LOCK TABLES `cmspropertytypegroup` WRITE;
/*!40000 ALTER TABLE `cmspropertytypegroup` DISABLE KEYS */;
INSERT INTO `cmspropertytypegroup` VALUES (3,NULL,1032,'Image',1),(4,NULL,1033,'File',1),(5,NULL,1031,'Contents',1),(11,NULL,1044,'Membership',1);
/*!40000 ALTER TABLE `cmspropertytypegroup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsstylesheet`
--

LOCK TABLES `cmsstylesheet` WRITE;
/*!40000 ALTER TABLE `cmsstylesheet` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsstylesheet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmsstylesheetproperty`
--

LOCK TABLES `cmsstylesheetproperty` WRITE;
/*!40000 ALTER TABLE `cmsstylesheetproperty` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmsstylesheetproperty` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmstagrelationship`
--

LOCK TABLES `cmstagrelationship` WRITE;
/*!40000 ALTER TABLE `cmstagrelationship` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmstagrelationship` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmstags`
--

LOCK TABLES `cmstags` WRITE;
/*!40000 ALTER TABLE `cmstags` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmstags` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmstask`
--

LOCK TABLES `cmstask` WRITE;
/*!40000 ALTER TABLE `cmstask` DISABLE KEYS */;
/*!40000 ALTER TABLE `cmstask` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmstasktype`
--

LOCK TABLES `cmstasktype` WRITE;
/*!40000 ALTER TABLE `cmstasktype` DISABLE KEYS */;
INSERT INTO `cmstasktype` VALUES (1,'toTranslate');
/*!40000 ALTER TABLE `cmstasktype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cmstemplate`
--

LOCK TABLES `cmstemplate` WRITE;
/*!40000 ALTER TABLE `cmstemplate` DISABLE KEYS */;
INSERT INTO `cmstemplate` VALUES (1,1046,NULL,'Home',' ');
/*!40000 ALTER TABLE `cmstemplate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracodomains`
--

LOCK TABLES `umbracodomains` WRITE;
/*!40000 ALTER TABLE `umbracodomains` DISABLE KEYS */;
/*!40000 ALTER TABLE `umbracodomains` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracolanguage`
--

LOCK TABLES `umbracolanguage` WRITE;
/*!40000 ALTER TABLE `umbracolanguage` DISABLE KEYS */;
INSERT INTO `umbracolanguage` VALUES (1,'en-US','en-US');
/*!40000 ALTER TABLE `umbracolanguage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracolog`
--

LOCK TABLES `umbracolog` WRITE;
/*!40000 ALTER TABLE `umbracolog` DISABLE KEYS */;
INSERT INTO `umbracolog` VALUES (1,0,1047,'2015-04-13 08:27:53','Save','Save ContentType performed by user'),(2,0,1047,'2015-04-13 08:28:06','Save','Save ContentType performed by user'),(3,0,1047,'2015-04-13 08:28:19','Save','Save ContentType performed by user'),(4,0,1047,'2015-04-13 08:28:31','Save','Save ContentType performed by user'),(5,0,0,'2015-04-13 08:28:40','New','Content \'\' was created'),(6,0,1048,'2015-04-13 08:28:51','Publish','Save and Publish performed by user'),(7,0,1048,'2015-04-13 08:29:15','Publish','Save and Publish performed by user'),(8,0,0,'2015-04-13 08:31:29','New','Media \'SPLDOLPHIN_380x254.jpg\' was created'),(9,0,1049,'2015-04-13 08:31:29','Save','Save Media performed by user'),(10,0,1048,'2015-04-13 08:31:48','Publish','Save and Publish performed by user');
/*!40000 ALTER TABLE `umbracolog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbraconode`
--

LOCK TABLES `umbraconode` WRITE;
/*!40000 ALTER TABLE `umbraconode` DISABLE KEYS */;
INSERT INTO `umbraconode` VALUES (-97,0,-1,0,1,'-1,-97',2,'aa2c52a0-ce87-4e65-a47c-7df09358585d','List View - Members','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-96,0,-1,0,1,'-1,-96',2,'3a0156c4-3b8c-4803-bdc1-6871faa83fff','List View - Media','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-95,0,-1,0,1,'-1,-95',2,'c0808dd3-8133-4e4b-8ce8-e2bea84a96a4','List View - Content','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-92,0,-1,0,1,'-1,-92',35,'f0bc4bfb-b499-40d6-ba86-058885a5178c','Label','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-90,0,-1,0,1,'-1,-90',34,'84c6b441-31df-4ffe-b67e-67d5bc3ae65a','Upload','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-89,0,-1,0,1,'-1,-89',33,'c6bac0dd-4ab9-45b1-8e30-e4b619ee5da3','Textbox multiple','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-88,0,-1,0,1,'-1,-88',32,'0cc0eba1-9960-42c9-bf9b-60e150b429ae','Textstring','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-87,0,-1,0,1,'-1,-87',4,'ca90c950-0aff-4e72-b976-a30b1ac57dad','Richtext editor','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-51,0,-1,0,1,'-1,-51',2,'2e6d3631-066e-44b8-aec4-96f09099b2b5','Numeric','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-49,0,-1,0,1,'-1,-49',2,'92897bc6-a5f3-4ffe-ae27-f2e7e33dda49','True/false','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-43,0,-1,0,1,'-1,-43',2,'fbaf13a8-4036-41f2-93a3-974f678c312a','Checkbox list','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-42,0,-1,0,1,'-1,-42',2,'0b6a45e7-44ba-430d-9da5-4e46060b9e03','Dropdown','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-41,0,-1,0,1,'-1,-41',2,'5046194e-4237-453c-a547-15db3a07c4e1','Date Picker','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-40,0,-1,0,1,'-1,-40',2,'bb5f57c9-ce2b-4bb9-b697-4caca783a805','Radiobox','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-39,0,-1,0,1,'-1,-39',2,'f38f0ac7-1d27-439c-9f3f-089cd8825a53','Dropdown multiple','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-38,0,-1,0,1,'-1,-38',2,'fd9f1447-6c61-4a7c-9595-5aa39147d318','Folder Browser','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-37,0,-1,0,1,'-1,-37',2,'0225af17-b302-49cb-9176-b9f35cab9c17','Approved Color','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-36,0,-1,0,1,'-1,-36',2,'e4d66c0f-b935-4200-81f0-025f7256b89a','Date Picker with time','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(-21,0,-1,0,0,'-1,-21',0,'bf7c7cbc-952f-4518-97a2-69e9c7b33842','Recycle Bin','cf3d8e34-1c1c-41e9-ae56-878b57b32113','2015-04-13 08:27:16'),(-20,0,-1,0,0,'-1,-20',0,'0f582a79-1e41-4cf0-bfa0-76340651891a','Recycle Bin','01bb7ff2-24dc-4c0c-95a2-c24ef72bbac8','2015-04-13 08:27:16'),(-1,0,-1,0,0,'-1',0,'916724a5-173d-4619-b97e-b9de133dd6f5','SYSTEM DATA: umbraco master root','ea7d8624-4cfe-4578-a871-24aa946bf34d','2015-04-13 08:27:16'),(1031,0,-1,0,1,'-1,1031',2,'f38bd2d7-65d0-48e6-95dc-87ce06ec2d3d','Folder','4ea4382b-2f5a-4c2b-9587-ae9b3cf3602e','2015-04-13 08:27:16'),(1032,0,-1,0,1,'-1,1032',2,'cc07b313-0843-4aa8-bbda-871c8da728c8','Image','4ea4382b-2f5a-4c2b-9587-ae9b3cf3602e','2015-04-13 08:27:16'),(1033,0,-1,0,1,'-1,1033',2,'4c52d8ab-54e6-40cd-999c-7a5f24903e4d','File','4ea4382b-2f5a-4c2b-9587-ae9b3cf3602e','2015-04-13 08:27:16'),(1034,0,-1,0,1,'-1,1034',2,'a6857c73-d6e9-480c-b6e6-f15f6ad11125','Content Picker','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1035,0,-1,0,1,'-1,1035',2,'93929b9a-93a2-4e2a-b239-d99334440a59','Media Picker','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1036,0,-1,0,1,'-1,1036',2,'2b24165f-9782-4aa3-b459-1de4a4d21f60','Member Picker','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1040,0,-1,0,1,'-1,1040',2,'21e798da-e06e-4eda-a511-ed257f78d4fa','Related Links','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1041,0,-1,0,1,'-1,1041',2,'b6b73142-b9c1-4bf8-a16d-e1c23320b549','Tags','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1043,0,-1,0,1,'-1,1043',2,'1df9f033-e6d4-451f-b8d2-e0cbc50a836f','Image Cropper','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1044,0,-1,0,1,'-1,1044',0,'d59be02f-1df9-4228-aa1e-01917d806cda','Member','9b5416fb-e72f-45a9-a07b-5a9a2709ce43','2015-04-13 08:27:16'),(1045,0,-1,0,1,'-1,1045',2,'7e3962cc-ce20-4ffc-b661-5897a894ba7e','Multiple Media Picker','30a2a501-1978-4ddb-a57b-f7efed43ba3c','2015-04-13 08:27:16'),(1046,0,-1,0,1,'-1,1046',0,'0aa95c33-a582-481b-b868-c3ae4532f2c9','Home','6fbde604-4178-42ce-a10b-8a2600a2f07d','2015-04-13 08:27:52'),(1047,0,-1,0,1,'-1,1047',0,'0503ab54-d561-4492-aa52-a408dcdead53','Home','a2cb7800-f571-4787-9638-bc48539a0efb','2015-04-13 08:27:52'),(1048,0,-1,0,1,'-1,1048',0,'8c557f99-372e-4df2-8730-8c4a524ca71c','Home','c66ba18e-eaf3-4cff-8a22-41b16d66a972','2015-04-13 08:28:50'),(1049,0,-1,0,1,'-1,1049',0,'d9d620d0-6788-4907-826a-24a6cd08654c','SPLDOLPHIN_380x254.jpg','b796f64c-1f99-4ffb-b886-4bf4bc011a9c','2015-04-13 08:31:29');
/*!40000 ALTER TABLE `umbraconode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracorelation`
--

LOCK TABLES `umbracorelation` WRITE;
/*!40000 ALTER TABLE `umbracorelation` DISABLE KEYS */;
/*!40000 ALTER TABLE `umbracorelation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracorelationtype`
--

LOCK TABLES `umbracorelationtype` WRITE;
/*!40000 ALTER TABLE `umbracorelationtype` DISABLE KEYS */;
INSERT INTO `umbracorelationtype` VALUES (1,1,'c66ba18e-eaf3-4cff-8a22-41b16d66a972','c66ba18e-eaf3-4cff-8a22-41b16d66a972','Relate Document On Copy','relateDocumentOnCopy');
/*!40000 ALTER TABLE `umbracorelationtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracoserver`
--

LOCK TABLES `umbracoserver` WRITE;
/*!40000 ALTER TABLE `umbracoserver` DISABLE KEYS */;
/*!40000 ALTER TABLE `umbracoserver` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracouser`
--

LOCK TABLES `umbracouser` WRITE;
/*!40000 ALTER TABLE `umbracouser` DISABLE KEYS */;
INSERT INTO `umbracouser` VALUES (0,0,0,1,-1,-1,'Michael Farr','michael@alphero.com','Password','michael@alphero.com','en');
/*!40000 ALTER TABLE `umbracouser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracouser2app`
--

LOCK TABLES `umbracouser2app` WRITE;
/*!40000 ALTER TABLE `umbracouser2app` DISABLE KEYS */;
INSERT INTO `umbracouser2app` VALUES (0,'content'),(0,'developer'),(0,'forms'),(0,'media'),(0,'member'),(0,'settings'),(0,'users');
/*!40000 ALTER TABLE `umbracouser2app` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracouser2nodenotify`
--

LOCK TABLES `umbracouser2nodenotify` WRITE;
/*!40000 ALTER TABLE `umbracouser2nodenotify` DISABLE KEYS */;
/*!40000 ALTER TABLE `umbracouser2nodenotify` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracouser2nodepermission`
--

LOCK TABLES `umbracouser2nodepermission` WRITE;
/*!40000 ALTER TABLE `umbracouser2nodepermission` DISABLE KEYS */;
/*!40000 ALTER TABLE `umbracouser2nodepermission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracouserlogins`
--

LOCK TABLES `umbracouserlogins` WRITE;
/*!40000 ALTER TABLE `umbracouserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `umbracouserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `umbracousertype`
--

LOCK TABLES `umbracousertype` WRITE;
/*!40000 ALTER TABLE `umbracousertype` DISABLE KEYS */;
INSERT INTO `umbracousertype` VALUES (1,'admin','Administrators','CADMOSKTPIURZ:5F7'),(2,'writer','Writer','CAH:F'),(3,'editor','Editors','CADMOSKTPUZ:5F'),(4,'translator','Translator','AF');
/*!40000 ALTER TABLE `umbracousertype` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-04-14  9:39:49
