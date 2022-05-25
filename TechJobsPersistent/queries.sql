--Part 1
SELECT * FROM techjobs.jobs;

--Part 2
SELECT *
FROM techjobs.employers
WHERE location="St. Louis";

--Part 3
SELECT *
FROM skills
LEFT JOIN jobskills ON skills.id = jobskills.SkillId
WHERE jobskills.jobid IS NOT NULL;
