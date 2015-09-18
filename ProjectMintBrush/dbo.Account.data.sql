declare @doc xml 
select @doc = Object from Account where ID = '1E80A10'
set @doc.modify('insert <IdentificationNumber><ID>testID</ID></IdentificationNumber> after (/AccountModel/EntriesOwned/IdentificationNumber)[1]')

update Account set Object = @doc where ID = '1E80A10'

