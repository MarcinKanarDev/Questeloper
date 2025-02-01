try {
       # Set the location to the Infrastructure directory
       Set-Location -Path "../../server/src/Questeloper.Infrastructure"

	Write-Host "Updating database..."

	dotnet ef database update --startup-project "../Questeloper.Api"

	Write-Host "Database updated!"
} catch {
        Write-Host "An error occurred while updating database: $_"
}
