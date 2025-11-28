create procedure insSocialLink
@Name nvarchar(max),
@Logo nvarchar(max),
@Url nvarchar(max)
as
Begin
insert into SocialLinks values(@Name, @logo, @Url)
select @@IDENTITY
End