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
- [ ] Add Unit tests!

## Housekeeping
- [ ] Re-organise project based on Clean Architecture principles

# Milestones
## 21/11/2023
- The rough capability to return an HTML document with the required script appended to it using HtmlAgilityPack.
- Put together a fairly simple page that executes a fetch request against the existing sample data endpoint and displays the result on page.

What I think I may do from here is to continue embedding the pages required resources at the point it's called by the `/api/ui` endpoint.
Images can be left to the `/api/resource` endpoint, though I may break these out into specific concerns depending on how I get along with general content.

![image](https://github.com/StuFrankish/MiddlewareMadness/assets/5624629/ea321fff-a170-43a0-affa-fa67b518b438)
