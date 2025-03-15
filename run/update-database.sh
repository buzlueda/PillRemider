#!/bin/bash

# Update the database (apply migrations)
echo "Applying migrations to update the database..."
dotnet ef database update -p src/PillReminder.Infrastructure/PillReminder.Infrastructure.Persistence -s src/PillReminder.Presentation/PillReminder.Presentation.WebAPI

if [ $? -eq 0 ]; then
  echo "Database successfully updated."
else
  echo "Failed to update the database."
  exit 1
fi
