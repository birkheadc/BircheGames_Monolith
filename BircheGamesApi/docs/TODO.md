# Todo

  - Time to start actually creating the program. I've unit tested most of what I currently have but I need to set up the actual program, first off is deciding what should be singleton, scoped, or transient. Then I need to make sure everything works together in dev, and the app is able to connect to aws. Finally need to stage it, make sure it all still runs when in the cloud

  - Create EmailService and EmailVerificationService as two separate things. EmailService simply sends email. EmailVerificationService uses EmailService to do the sending, but also processes verification requests and (re)send verification email requests