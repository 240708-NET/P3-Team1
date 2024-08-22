## Courses

```sql
- ID: int
- Name: varchar
- Description: text
- Category: varchar(50)
--- Prerequisites (stretch)
```

## Sections

```sql
- ID: int
- CourseID: int
- ProfessorID: int
- StartTime: time
- EndTime: time
- Day: varchar(5)
```

## Professors

```sql
- ID: int
- FirstName: varchar(50)
- LastName: varchar(50)
- Password: varchar(50)
```

## StudentSections

```sql
- ID: int
- SectionID: int
- StudentID: int
--- Grade/ Pass(No Pass) Stretch
```

## Students

```sql
- ID: int
- FirstName: varchar(50)
- LastName: varchar(50)
- Password: varchar(50)
```
