create procedure delSocialLink
@Id int
as
delete from SocialLinks where Id=@Id