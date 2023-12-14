# Todo

  - Time to start actually creating the program. I've unit tested most of what I currently have but I need to set up the actual program, first off is deciding what should be singleton, scoped, or transient. Then I need to make sure everything works together in dev, and the app is able to connect to aws. Finally need to stage it, make sure it all still runs when in the cloud

  - Test SecurityTokenGenerator against SecurityTokenValidator and program's authentication to make sure they are compatible
    - Also, is there a better way to AddAuthorization in program? Maybe tell it to use a specific class rather than just write the code in program.cs?