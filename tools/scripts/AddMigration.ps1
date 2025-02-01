$migrationName = Read-Host -Prompt "Please enter the name of the migration"

if ([string]::IsNullOrWhiteSpace($migrationName)) {
    Write-Host "Migration name cannot be empty. Exiting script."
} else {
    try {
        # Set the location to the Infrastructure directory
        Set-Location -Path "../../server/src/Questeloper.Infrastructure"

        dotnet ef migrations add $migrationName -o ".\Persistence\Migrations" --startup-project "../Questeloper.Api"

        Write-Host "Migration '$migrationName' added successfully."
	
	Write-Host "Updating database..."
	dotnet ef database update
	Write-Host "Database updated!"
    } catch {
        Write-Host "An error occurred while adding the migration: $_"
    }
}
