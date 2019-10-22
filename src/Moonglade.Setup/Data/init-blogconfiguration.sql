﻿DELETE FROM BlogConfiguration

INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (1, 'BlogOwnerSettings', '{"Name":"Admin","Description":"Moonglade Admin","ShortDescription":"Moonglade Admin","AvatarBase64":""}', GETDATE())
INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (2, 'ContentSettings', '{"EnableComments":true,"UseFriendlyNotFoundImage":true,"EnableWordFilter":false,"PostListPageSize":10,"HotTagAmount":10,"DisharmonyWords":"fuck|shit"}', GETDATE())
INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (3, 'EmailSettings', '{"EnableEmailSending":true,"EnableSsl":true,"SendEmailOnCommentReply":true,"SendEmailOnNewComment":true,"SmtpServerPort":587,"AdminEmail":"","EmailDisplayName":"Moonglade","SmtpPassword":"","SmtpServer":"","SmtpUserName":"","BannedMailDomain":""}', GETDATE())
INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (4, 'FeedSettings', '{"RssItemCount":20,"RssCopyright":"(c) {year} Moonglade","RssDescription":"Latest posts from Moonglade","RssGeneratorName":"Moonglade","RssTitle":"Moonglade","AuthorName":"Admin"}', GETDATE())
INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (5, 'GeneralSettings', '{"SiteTitle":"Moonglade","LogoText":"moonglade","MetaKeyword":"moonglade","Copyright":"&copy; 2019","SideBarCustomizedHtmlPitch":"","FooterCustomizedHtmlPitch":""}', GETDATE())
INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (6, 'WatermarkSettings', '{"IsEnabled":true,"KeepOriginImage":false,"FontSize":20,"WatermarkText":"Moonglade"}', GETDATE())
INSERT BlogConfiguration (Id, CfgKey, CfgValue, LastModifiedTimeUtc) VALUES (7, 'FriendLinksSettings', '{"ShowFriendLinksSection":true}', GETDATE())