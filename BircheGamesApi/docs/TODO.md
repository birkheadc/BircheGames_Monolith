# Todo

  - Time to start actually creating the program. I've unit tested most of what I currently have but I need to set up the actual program, first off is deciding what should be singleton, scoped, or transient. Then I need to make sure everything works together in dev, and the app is able to connect to aws. Finally need to stage it, make sure it all still runs when in the cloud

  - Create EmailService and EmailVerificationService as two separate things. EmailService simply sends email. EmailVerificationService uses EmailService to do the sending, but also processes verification requests and (re)send verification email requests
    - Build them with TDD. Create a mock of the amazon email service and test whether its methods are called properly.

  - Replace "Not Implemented Exceptions" in mocks with a custom exception so that the console is more informative while testing.

  - Test SecurityTokenGenerator against SecurityTokenValidator and program's authentication to make sure they are compatible
    - Also, is there a better way to AddAuthorization in program? Maybe tell it to use a specific class rather than just write the code in program.cs?

  - Rewrite unit tests to use:
    - Basic Mock abstract class
    - Intentional Exception rather than Not Implemented
      - (Not implemented can be left on methods that are not implemented, but throw intentional when... intentional)