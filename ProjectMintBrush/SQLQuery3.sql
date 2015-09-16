declare @doc xml
select @doc = Object from Account where ID = '1E80A10'
if @doc IS NOT NULL
	BEGIN
		set @doc.modify('delete AccountModel/EntriesOwned/IdentificationNumber/ID[text()][contains(.,"testID")]') 
		set @doc.modify('delete AccountModel/EntriesOwned/IdentificationNumber[empty(./*)]') 
		update Account set Object = @doc where ID = '1E80A10'
	END
select Object from Account where ID = '1E80A10'