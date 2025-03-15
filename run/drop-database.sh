#!/bin/bash

# Drop the database
echo "Starting database drop..."
dotnet ef database drop -p src/PillReminder.Infrastructure/PillReminder.Infrastructure.Persistence -s src/PillReminder.Presentation/PillReminder.Presentation.WebAPI -f

if [ $? -eq 0 ]; then
  echo "Database successfully dropped."
else
  echo "Failed to drop the database."
  exit 1
fi
