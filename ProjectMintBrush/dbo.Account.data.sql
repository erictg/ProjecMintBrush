declare @doc xml 
select @doc = Object from Account where ID = 'F1C166C'
set @doc.modify('insert <IdentificationNumber><ID>testID</ID></IdentificationNumber> after (/AccountModel/EntriesOwned/IdentificationNumber)[1]')

update Account set Object = @doc where ID = 'F1C166C'

