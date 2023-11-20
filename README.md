# MiddlewareMadness

[![.NET Build](https://github.com/StuFrankish/MiddlewareMadness/actions/workflows/dotnet.yml/badge.svg)](https://github.com/StuFrankish/MiddlewareMadness/actions/workflows/dotnet.yml)

The goal is to learn about writting good quality middleware, while making use of some of the official .Net 8 (LTS) goodness released very recently.
My secondary goal is to take what I learn here and build a more complete solution based around a fictious accounting application.

Some of the things I'm exploring and using are;
- Custom endpoint routing (find, process and execute multiple registered endpoints)
- Integrating Serilog directly into the middleware
- Embedding a UI framework

The Web Application is just a testing ground to test and use my middleware, so you'll find it boring with a side of bland, everything happens in the ApiMiddleware project.

## To Do
- [x] Integrate Serilog
- [x] Endpoint routing (check if the url path relates to a known endpoint, find a handler and handle it)
- [x] Endpoint for returning data (Json data for the UI)
- [ ] Endpoint for returning UI framework
- [ ] Endpoint to return static content (like Javascript & images)
- [ ] Enhance endpoints with authentication

## Housekeeping
- [ ] Re-organise project based on Clean Architecture principles
- [ ] Add Unit tests!
