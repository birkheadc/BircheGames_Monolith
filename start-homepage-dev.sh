#!/bin/bash

# Launches multiple services at once in dev environment

echo ""
echo "Starting Homepage+API Development Environment..."
echo ""
echo ""
dotnet run --project ./BircheGamesApi/BircheGamesApi/BircheGamesApi.csproj &
trap 'pkill -P $$' SIGINT SIGTERM
wait