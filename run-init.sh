#!/bin/bash
set -e

# Wait for SQL Server to be ready
echo "Waiting for SQL Server to be ready..."
until /opt/mssql-tools/bin/sqlcmd -S db -U sa -P "$SA_PASSWORD" -Q "SELECT 1" &> /dev/null
do
  sleep 1
done

# Run the initialization script
echo "Running initialization script..."
/opt/mssql-tools/bin/sqlcmd -S db -U sa -P "$SA_PASSWORD" -d master -i db-init-full.sql

echo "Initialization script executed successfully!"

