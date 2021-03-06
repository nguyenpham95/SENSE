USE [SenseDBs]
GO
/****** Object:  Table [dbo].[announcement]    Script Date: 2/14/2016 1:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[announcement](
	[Title] [nvarchar](500) NOT NULL,
	[Content] [nvarchar](2000) NOT NULL,
	[Date] [date] NOT NULL,
	[authorID] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[faci]    Script Date: 2/14/2016 1:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[faci](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Link] [nvarchar](500) NULL,
	[Model] [nvarchar](500) NULL,
	[Purpose] [nvarchar](500) NULL,
	[Description] [nvarchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[noti]    Script Date: 2/14/2016 1:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[noti](
	[userID] [nvarchar](50) NOT NULL,
	[action] [nvarchar](2000) NULL,
	[date] [date] NULL,
	[link] [nvarchar](500) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[project]    Script Date: 2/14/2016 1:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project](
	[ID] [nvarchar](500) NOT NULL,
	[ProjectName] [nvarchar](500) NULL,
	[AuthorID] [nvarchar](50) NULL,
	[AdvisorID] [nvarchar](50) NULL,
	[Description] [nvarchar](4000) NULL,
	[TimelineLink] [nvarchar](150) NULL,
	[AvaLink] [nvarchar](150) NULL,
	[Status] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[Duedate] [date] NULL,
	[CompletePercent] [nvarchar](50) NULL,
	[Stage] [nvarchar](50) NULL,
	[Boxtype] [nvarchar](50) NULL,
	[Code] [nvarchar](2000) NULL,
	[Shortname] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[upload]    Script Date: 2/14/2016 1:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[upload](
	[filename] [nvarchar](500) NULL,
	[date] [date] NULL,
	[status] [nvarchar](50) NULL,
	[link] [nvarchar](500) NULL,
	[authorID] [nvarchar](50) NULL,
	[project] [nvarchar](500) NULL,
	[Description] [nvarchar](2000) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 2/14/2016 1:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surename] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[Ava] [nvarchar](50) NULL,
	[Pass] [nvarchar](50) NOT NULL,
	[Degree] [nvarchar](550) NULL,
	[Mail] [nvarchar](150) NULL,
	[Link] [nvarchar](50) NULL,
	[Bio] [nvarchar](2000) NULL,
	[Interest] [nvarchar](2000) NULL,
	[AdvisorID] [nvarchar](50) NULL,
	[Completename] [nvarchar](150) NULL,
	[Phone] [nvarchar](50) NULL,
	[Code] [nvarchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[announcement] ([Title], [Content], [Date], [authorID]) VALUES (N'Finish SENSE LAB ver1.0', N'Has finished updating SENSE Lab Website', CAST(N'2016-02-14' AS Date), N'BEBEIU13051')
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC01', N'Polysomnography', N'userStuff/faci/poly.png', N'Philips-Alice5', N'Research', NULL)
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC02', N'CPAP', N'userStuff/faci/cpap.png', N'Philips Respironics', N'Research', NULL)
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC03', N'Bedside Monitoring System', N'userStuff/faci/bms.png', N'Nihon-Kohden', N'Research', NULL)
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC04', N'Electrocardiography Machine', N'userStuff/faci/em.png', N'Nihon-Kohden', N'Research', NULL)
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC06', N'Ultrasound Machine', N'userStuff/faci/um.png', N'Acuson 128XP/10c', N'Research', NULL)
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC07', N'Aneroid Sphygmomanometer', N'userStuff/faci/esy.png', N'Yamasu', N'Research', NULL)
INSERT [dbo].[faci] ([ID], [Name], [Link], [Model], [Purpose], [Description]) VALUES (N'FC08', N'Treadmill for Stress Test', N'userStuff/faci/tfst.png', NULL, N'Research', NULL)
INSERT [dbo].[noti] ([userID], [action], [date], [link]) VALUES (N'BEBEIU13051', N'has updated members'' profiles', CAST(N'2016-02-14' AS Date), N'#profiles/')
INSERT [dbo].[noti] ([userID], [action], [date], [link]) VALUES (N'BEBEIU13051', N'has upload Sense lab source code ver 1.0', CAST(N'2016-02-11' AS Date), N'userStuff/upload/SENSE.zip')
INSERT [dbo].[noti] ([userID], [action], [date], [link]) VALUES (N'BEBEIU13051', N'finished profile update function', CAST(N'2016-02-09' AS Date), N'update_profile.aspx')
INSERT [dbo].[noti] ([userID], [action], [date], [link]) VALUES (N'BEBEIU13051', N'finished upload files function', CAST(N'2016-02-09' AS Date), N'workspace.aspx')
INSERT [dbo].[project] ([ID], [ProjectName], [AuthorID], [AdvisorID], [Description], [TimelineLink], [AvaLink], [Status], [Date], [Duedate], [CompletePercent], [Stage], [Boxtype], [Code], [Shortname]) VALUES (N'amiPrediction', N'Predicting the onset of Acute Myocardial Infarction using ECG signal', N'BEBEIU13051', N'BEBETC01', N'This research focuses on finding the prognostic value of ECG for early detection of Acute Myocardial Infarction by looking at its unusual waveforms and corresponds these abnormalities with the common ECG patterns before AMI occurs. The goal of this research is developing an algorithm to detect abnormal patterns in ECG waveform and thus forecast the occurrence of AMI. The algorithm then can be used for various different application developments, for example, one can use the algorithm to make a mobile or web-based application to predict and detect AMI.  ', N'none', N'userStuff/project/ava/ami.png', N'New', CAST(N'2015-09-12' AS Date), CAST(N'2018-05-20' AS Date), N'12%', N'1', N'none', N'none', N'AMI Prediction')
INSERT [dbo].[project] ([ID], [ProjectName], [AuthorID], [AdvisorID], [Description], [TimelineLink], [AvaLink], [Status], [Date], [Duedate], [CompletePercent], [Stage], [Boxtype], [Code], [Shortname]) VALUES (N'senseLab', N'SENSE Lab Websire Platform Development', N'BEBEIU13051', N'none', N'SENSE Lab is an integrated website that allow members of BME A1.513 at Internatioanl University to publish thier works and articles for research purposes. This code is completely open source and is built on top of current website technologies including: Google Angular Js for both backend and front end, Dashboard Gum Template and ASP.NET 4.', N'none', N'userStuff/project/ava/sense.png', N'New', CAST(N'2016-01-12' AS Date), CAST(N'2016-02-15' AS Date), N'80%', N'4', N'none', N'none', N'SENSE Lab Website')
INSERT [dbo].[upload] ([filename], [date], [status], [link], [authorID], [project], [Description]) VALUES (N'Enbeding with matlab Case Study', CAST(N'2016-02-14' AS Date), N'Accessible', N'userStuff/upload/Enbeding with matlab Case Study.pdf', N'BEBEIU13051', N'amiPrediction', N'')
INSERT [dbo].[upload] ([filename], [date], [status], [link], [authorID], [project], [Description]) VALUES (N'SENSE LAB Soure Code', CAST(N'2016-02-14' AS Date), N'Accessible		', N'userStuff/upload/SENSE.zip', N'BEBEIU13051', N'senseLab	', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEEX01', N'Quan ', N'Tran', N'Medicine and Research Exchange Student', CAST(N'2016-01-15' AS Date), N'userStuff/ava/minhquan.jpg', N'123', N'Degree of Medicine', N'tranminhquanc123@yahoo.com', N'quantran', N'My name is Trần Minh Quân. I am currently a senior student of Phạm Ngọc Thạch university of medicine and studying to be a doctor. After graduation, I would like to begin a career in medical research, mainly involve biomedical engineering and bioinformatics. My interest is analysing biosignal data (ECG and EEG for specific) to early detect and predict the disorders of human brain or heart. Although my background is medicine and a little bit of programming, I am also interested in data analysis and developing medical device. In my spare time, I usually listen to music, origami, or finding what currently happen in the science world. My favourite topics are music, science and astronomy. ', N'My current research is using an electrophysiological brain model to analyse the EEG data from patients who have epilepsy or parkinson. These data can show how the deep brain regions activated during the epilepsy period or in parkinson patients. After that, revealing the progression of the electrophysiological pathway of each patient''s brain when they suffer these diseases. Finally, these data will be helpful to develop a device that can record the EEG of the patients continously ,provide information for neurologist to diagnose and manage the progression of the diseases, and also finding the suitable approach to treat them.', N'BEBETC01', N'Tran Minh Quan', N'0902986408', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEIU13022', N'Huy', N'Pham', N'Undergraduate Student', CAST(N'2016-01-14' AS Date), N'userStuff/ava/quochuy.jpg', N'123', N'Bachelor degree of Biomedical Engineer', N'phamquochuy725@gmail.com', N'huypham', N'Huy Q. Pham: was born in Cu Chi, Viet Nam. He is currently a senior student of Biomedical Engineering Department of International University, National University, HCMC. His current interests include developing wearable medical devices by utilizing acoustic waves for diseases treament and commercializing the product on the market. He achieved an encouraged scholarship in semester 2 of 2013-2014; “Sinh vien 5 tot” title and the 2nd prize in “Toi Khoi Khiep 2015” competition as a front-end coder of Spime team. He also joined IU Guitar Club, BME Newsletter; attended many BME activities as an organizing member (Ao dai show, Study Trip 2014) and did several volunteer works (Mua he xanh 2014, Orphan Impact of The Jailbreak 2014). He likes listening to music, playing musical instruments (guitar, harmonica).', N'We are developing a device that utilizes ultrasonic waves in order to treat Obstructive Sleep Apnea (OSA) or even blood clots. The device will be able to target and manipulate the nerve that controls the back of the tongue to reverse the pharyngeal constriction which is a reason for OSA. Specifically, we would build a flat ultrasonic transducers array and investigate its ability of noncontact levitating and manipulating a small sphere (traslation, rotation and spin) first then consider the nerve. The research approach is separated in 5 parts: building the transducers array, implementing algorithms by MatLab, controling the sphere, targeting the nerve position and manipulating the nerve. Besides the benefits of treating diseases, this device might also be a useful tool to support other researches such as drug delivery, cell manipulation…', N'BEBETC01', N'Pham Quoc Huy', N'0166 8915 955', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEIU13051', N'Nguyen', N'Pham', N'Undergraduate Student', CAST(N'2016-01-12' AS Date), N'userStuff/ava/khoinguyen.jpg', N'123', N'Bachelor degree of Biomedical Engineer', N'phamkhoinguyen1995@gmail.com', N'nguyenpham', N'I was born and rised in a small village at the southen of Vietnam. The landscape of the village is magnificent, it always makes me feel warm remembering when I spend my time under the shade of coconut trees studying. I love how hamonily people here treat each other, something you just cant find elsewhere. At the age of 12 I have shown great interest in reading books, and I learn HTML language since then. Later my family moves into Ho Chi Minh City, where I find out what I love and who I truly am. Coding means the world to me, the world that I cound paint with the language of text and coffee. It makes me feel extremely happy that I could spend every second to do what I truly love and create something that benefit people. I want to return to my home village someday, bringing along with me the world I created, to improve the quality of education for children there.', N'Although he is reticent, he has a very warm heart and a hungry mind who always eager to learn new skills. He is also a sophomore at International University, HCM City and he has one year of experience building website. His design taste is developing beautiful and interactive user interface following the google design guidline. After developing his first project, SENSE Lab website, he will focus on his core Spime Project, which is also an integrated website that help connects students with university professors for research and academic purposes. He is also a junior Matlab user who get really interested in Biological Signal Processing and Prediction. He also know a little bit about hardware programming and is constantly improving his skills in this new field.', N'BEBETC01', N'Pham Khoi Nguyen', N'0914 11 88 96', N'')
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEIU13096', N'Trung', N'Tran', N'Undergraduate Student', CAST(N'2016-01-13' AS Date), N'userStuff/ava/trungtran.jpg', N'123', N'Bachelor degree of Biomedical Engineer', N'minhtrung125@gmail.com', N'trungtran', N'Introduction: Eager to learn and grow professionally. My skills are Structured Query Language and electrical engineering.', N'Blood pressure has always been considered as one of the most common vital signals because of its significant value in the diagnosis of the cardiovascular diseases and stroke. Two techniques of indirect blood pressure (BP) measurement are currently used for ambulatory blood pressure measurement including the auscultatory and oscillometric methods. Although, these techniques are non-invasive, it has been shown to be uncomfortable, inconvenient and unable to measure blood pressure continuously. Therefore, a wearable cuff-less device is needed to optimize the measurement of blood pressure as it can remove the pain caused by the inflatable cuff and provide real-time blood pressure measurement.', N'BEBETC01', N'Tran Minh Trung', N'Updating...', N'')
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEMA01', N'Cuc', N'Bui', N'Master Student', CAST(N'2016-01-16' AS Date), N'userStuff/ava/cucbui.jpg', N'123', N'Bachelor of Aviation Academy and Master degree of Biomedical Engineer', N'cucbui.dtvt90@gmail.com', N'cucbui', N'Cuc  was born in Hai Phong, Viet Nam. She is currently studying toward the Master degree in the Department of Biomedical Engineering, International University, Ho Chi Minh City, Viet Nam. she has studied  4 years for the undergraduate background of electronics and telecommunications  in University of Viet Nam aviation academy, Ho Chi Minh City. She thinks about herself as an open-minded, confident and motivated woman who aims for broadening her wisdom horizon as much as she can. She is a woman decisively, humour and responsible for job. Her leisure time spends on books and physical activities like do exercise  or rumba dance.   ', N'She is currently pursuing 2 researchs. The first one is Investigating short-term prediction using Kalman filter. This research  aims to use Kalman filter to predict the occurrence of disorder onsets, especially in acute diseases and use MATLAB to simulate signal. Her second study is about “heart simulator” use MATLAB simulink and analyze signal to service for dianogtic. Models can be made practical for testing. Now, she is studying about MATLAB and reading the papers ralated to the topic.', N'BEBETC01', N'Bui Thi Cuc', N'+84 1696938076', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEMA02', N'Quyen', N'Huynh', N'Master Student', CAST(N'2016-01-17' AS Date), N'userStuff/ava/baoquyen.jpg', N'123', N'Bachelor of Aviation Academy and Master degree of Biomedical Engineer', N'huynhquyen.dtvt@gmail.com', N'quyenhuynh', N'Quyen Huynh was born in Quang Nam. She is currently studying toward the Master degree in the Department of Biomedical Engineering, International University, Ho Chi Minh City, Viet Nam although she has spent 4 years for gaining the undergraduate background of Electronic & Telecommunication in Viet Nam Aviation Academy, Ho Chi Minh City. The reason why she makes this change is because she wishes to contribute on the progress of medicine. Her free time spends on books and music. She thinks that she is quite humorous, helpful and diligent.  ', N'She is currently pursuing 2 researches. The first one is investigation of the alternative Polysomnography (PSG) system for at-home Obstructive Sleep Apnea monitoring and detection. The principle of the research is based on the measurement of the decreases in amplitude of the PPG signal (DAP) since they are related to vasoconstriction associated to apnea. The significant characteristic of this system is that it could replace effectively Polysomnography (PSG) system at sleep clinics. Her second study is to use the ultrasound to image the building damaged by   Holographic acoustic and then treat it by Acoustic levitation method which using acoustic radiation pressure from intense sound waves in the medium to break the blood clots in the vein of varicose veins disease, widening the block of artery.', N'BEBETC01', N'Huynh Thi Bao Quyen', N'+84 1662623459', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEMA03', N'Phuong', N'Bui', N'Master Student', CAST(N'2016-01-18' AS Date), N'userStuff/ava/ngocphuong.jpg', N'123', N'Bachelor of Aviation Academy and Master degree of Biomedical Engineer', N'nphuong.bt@gmail.com', N'phuongbui', N'Phuong Bui was born in Quang Ngai, Viet Nam. She is currently studying toward the Master degree in the Department of Biomedical Engineering, International University, Ho Chi Minh City, Viet Nam although she has spent 5 years for gaining the undergraduate background of Pharmacy in University of Medicines and Pharmacy, Ho Chi Minh City. She thinks about herself as an open-minded and motivated woman who aims for broadening her wisdom horizon as much as she can. She is diligent, helpful, and has a good sense of humour. Her leisure time spends on books and physical activities like swimming, workout or dancing.   ', N'She is currently pursuing 2 researchs. The first one is Lab-on-Chip for Malaria detection. This research combines knowledge of molecular biology, microelectronics and optics, using LAMP (Loop-mediated isothermal Ampilfication) technique, Microfluidic chip and Fluororescence in order to detect quickly Malaria parasites in patient blood for Point-of-Care. Her second study is about the investigation of the alternative Polysomnography (PSG) system for at-home Obstructive Sleep Apnea monitoring and detection. It is a big challenge for her because it requires her to understand deeply in very new knowledge of engineering, which is totally different from her bachelor background, Pattern Classification, Real-time Prediction and Electronic Wearable Device; however, she is so eager for this new intellectual journey.', N'BEBETC01', N'Bui Thi Ngoc Phuong', N'+84 934845501', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBEMA04', N'Tuan', N'Nguyen', N'Lab Technician and Master Student', CAST(N'2016-01-19' AS Date), N'userStuff/ava/hoangtuan.jpg', N'123', N'Master degree of Biomedical Engineer', N'nguyen.hoangtuan4@gmail.com', N'tuannguyen', N'Nguyen Hoang Tuan is a Biomedical engineer. He awarded his BSc. by the Biomedical Engineering department at the International University in October, 2015. He is specialized in medical devices developing, skillful in computer aid design, and technically proficient in microcontroller programing. Tuan is now working at the Biomedical Engineering Department as a research engineer. ', N'Tuan has extensive research experience in the department of Biomedical Engineering at International University, most of it focused on wearable medical instrumentations. In it, he developed a low-cost, wearable electrocardiograph (ECG) monitor aiming at long-term patient monitoring. His current research works are about automation mechatronics such as 3D printing and CNC technology, and development of the Lab-on-chip devices for biomedical applications.  ', N'BEBETC01', N'Nguyen Hoang Tuan', N'+84934772135', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBETC01', N'Trung', N'Le', N'Researcher, Lecturer and Advisor', CAST(N'2016-01-20' AS Date), N'userStuff/ava/trungle.jpg', N'123', N'He received his PhD''s degree from Oklahoma State University and was a Postdoctoral research associate of Industrial Systems Engineering and a Research scientist of Biomedical Engineering at Texas A&M University. ', N'lequoctrung@gmail.com', N'trungle', N'Dr. Trung Le is a Lecturer of Biomedical Engineering Department at International University – HCMC National University. He received his PhD''s degree from Oklahoma State University and was a Postdoctoral research associate of Industrial Systems Engineering and a Research scientist of Biomedical Engineering at Texas A&M University. He collaborates closely with cardiologists, sleep physician, health scientists and bio-medical researchers to perform his research activies.', N'His research comprises of three complementary directions including: (1) point of care wearable sensor technology for the monitoring and prognostics of cardiorespiratory and sleep disorders (2) high-specificity diagnostic methods for identifying and localizing cardiovascular disorders to mine unstructured content from the vital signs in healthcare to convert it into clinically significant information interpretable by physicians and doctors, and (3) advanced analytics approaches to forecast the time to the impending cardiorespiratory risks or disorders before they actually happen for warning control applications and/or preventive medicines. His work was published in IEEE Journal of Biomedical Engineering, Medical Engineering and Physics, and IEEE Journal of Translational Engineering in Health and Medicine. His work have led to several US and International patents.   ', N'none', N'Le Quoc Trung', N'0915 538 938', NULL)
INSERT [dbo].[user] ([ID], [Name], [Surename], [Type], [Date], [Ava], [Pass], [Degree], [Mail], [Link], [Bio], [Interest], [AdvisorID], [Completename], [Phone], [Code]) VALUES (N'BEBETC02', N'Tho', N'Le', N'Researcher, Doctor and Lecturer', CAST(N'2016-01-21' AS Date), N'userStuff/ava/cotho.jpg', N'123', N'Master degree of Medicine', N'tho.anh.le@gmail.com', N'thole', N'Dr. Tho A. Le is also a Lecturer of Biomedical Engineering Department at International University – HCMC National University. ', N'Being a senior cardiologist with more than 15 years of clinical practice, she has long been devoted to identifying the risk of cardiovascular and neurological diseases especially Sleep Disorders and Metabolic Syndrome, which contributed to her Master Thesis at HCMC University of Medicine and Pharmacology. Her experiences as the Clinical Consultant and Medical Advisor in many Health Projects including the NGOs and the National Programs are another advantages for our studies.', N'none', N'Le Anh Tho', N'Updating...', NULL)
