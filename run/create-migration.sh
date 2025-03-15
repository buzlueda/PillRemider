#!/bin/bash

# Generate a unique migration name based on the current timestamp
migration_name="Migration_$(date +%Y%m%d_%H%M%S)"

# Create a new migration
echo "Creating a new migration with name: $migration_name ..."
dotnet ef migrations add $migration_name -p src/PillReminder.Infrastructure/PillReminder.Infrastructure.Persistence -s src/PillReminder.Presentation/PillReminder.Presentation.WebAPI

if [ $? -eq 0 ]; then
  echo "Migration '$migration_name' created successfully."
else
  echo "Failed to create migration."
  exit 1
fi
