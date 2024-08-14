```sql
Courses
- ID: int
- Name: varchar
- Description: varchar(max)
- Category: varchar(?)
--- Prerequisites (stretch)
```

```sql
Sections
- ID: int
- Course ID: int
- Professor ID: int
- Start-Time: time
- End-Time: time
- Day: varchar(5)
```

```sql
Professors
- ID: int
- First Name: varchar(?)
- Last Name: varchar(?)
```

```sql
StudentSections -- (Stretch)
- ID: int
- SectionID: int
- StudentID: int
--- Grade/ Pass(No Pass) Stretch 
```

```sql
Students
- ID: int
- First Name: varchar(?)
- Last Name: varchar(?)
```
