## Courses
```sql
- ID: int
- Name: varchar
- Description: varchar(max)
- Category: varchar(?)
--- Prerequisites (stretch)
```

## Sections
```sql
- ID: int
- Course ID: int
- Professor ID: int
- Start-Time: time
- End-Time: time
- Day: varchar(5)
```

## Professors
```sql
- ID: int
- First Name: varchar(?)
- Last Name: varchar(?)
```
## StudentSections 
```sql
-- (Stretch)
- ID: int
- SectionID: int
- StudentID: int
--- Grade/ Pass(No Pass) Stretch 
```

## Students
```sql
- ID: int
- First Name: varchar(?)
- Last Name: varchar(?)
```
