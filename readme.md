# Simple_API_Assessment

## SEEDING Database

- On open the API will add an applicant named Mathews with three (3) skills to the database using the DBInitializer class

## Database

- Postgresql Docker container
* Run docker compose up -d

## API Url - Must run Docker first for the API to seed data into the database

- http://localhost:5000
* dotnet run

## End points and Paths

### Applicant end points

- GET /applicants
* Return all the applicants with their skills

- GET /applicants/1
* Return a single applicant with an id equals to 1, with their skills

- POST /applicants
* Add an applicant with or without skills
* e.g {
  name: "Mathews",
  skills:[
  {
  name: "SQL"
  }
  ]
  }

- PUT /applicants
* Update an applicant with an id from the applicant object
* e.g {
  id: 1,
  name: "Mathews"
  }

- DELETE /applicants/1
* Remove an applicant with a given id of 1

### Skill end points

- GET /skills
* Return all the skills

- GET /skills/1
* Return a single skill with an id equals to 1

- POST /skills/1
* Add a skill to a list of skills that belongs to an applicant with id of 1
* e.g
  {
  name: "SQL"
  }

- PUT /skills
* Update a skill with an id from the skills object
* e.g {
  id: 1,
  name: "Html"
  }

- DELETE /skills/1
* Remove an skill with a given id of 1
