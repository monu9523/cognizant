# Git Week-7 Hands-on Lab

## Repository

GitHub Repository: https://github.com/monu9523/cognizant

---

# Objective

This repository contains the solutions for the Git Week-7 Hands-on exercises covering:

- Git Configuration
- Git Ignore
- Branching and Merging
- Merge Conflict Resolution
- Clean Up and Push to Remote Repository

---

# Task 1 - Git Configuration

## Objectives

- Configure Git
- Set Notepad++ as the default editor
- Initialize a Git repository
- Add and commit files
- Push changes to GitHub

## Commands Used

```bash
git --version

git config --global user.name "Roshni"

git config --global user.email "your-email@example.com"

git config --list

git config --global core.editor "'C:/Program Files/Notepad++/notepad++.exe' -multiInst -nosession"

git init

git status

git add .

git commit -m "Completed Git Configuration Hands-on"

git pull origin main

git push origin main
```

---

# Task 2 - Git Ignore

## Objectives

- Ignore unwanted files
- Ignore log folders

## Files Created

```
sample.log
log/
└── error.txt
.gitignore
```

## .gitignore

```gitignore
*.log
log/
*.bak
```

## Commands Used

```bash
touch sample.log

mkdir log

echo "Error Log" > log/error.txt

git status

git add .gitignore

git commit -m "Implemented Git Ignore"

git push origin main
```

---

# Task 3 - Branching and Merging

## Objectives

- Create a new branch
- Modify files
- Merge branch into main

## Commands Used

```bash
git checkout -b GitNewBranch

git branch -a

echo "This file was created in GitNewBranch." > branch-demo.txt

git add branch-demo.txt

git commit -m "Added branch-demo.txt"

git checkout main

git diff main GitNewBranch

git merge GitNewBranch

git log --oneline --graph --decorate

git branch -d GitNewBranch

git push origin main
```

---

# Task 4 - Merge Conflict Resolution

## Objectives

- Create merge conflict
- Resolve merge conflict
- Commit resolved version

## Commands Used

```bash
git checkout -b GitWork

echo "<message>Hello from GitWork Branch</message>" > hello.xml

git add hello.xml

git commit -m "Added hello.xml in GitWork"

git checkout main

echo "<message>Hello from Main Branch</message>" > hello.xml

git add hello.xml

git commit -m "Added hello.xml in Main"

git merge GitWork

git add hello.xml

git commit -m "Resolved merge conflict in hello.xml"

git push origin main
```

---

# Task 5 - Clean Up and Push

## Objectives

- Verify clean working tree
- Pull latest changes
- Push latest commits

## Commands Used

```bash
git status

git branch

git branch -a

git pull origin main

git push origin main

git log --oneline --graph --decorate
```

---

# Git Commands Reference

| Command | Description |
|----------|-------------|
| git init | Initialize repository |
| git status | Check repository status |
| git add . | Stage all files |
| git commit -m | Commit changes |
| git branch | List branches |
| git checkout | Switch branches |
| git checkout -b | Create and switch branch |
| git merge | Merge branches |
| git diff | Compare branches |
| git log --oneline --graph --decorate | View commit history |
| git pull | Fetch latest changes |
| git push | Push commits to remote |
| git branch -d | Delete merged branch |

---

# Folder Structure

```
Git(Week-7)
│
├── README.md
├── .gitignore
├── branch-demo.txt
├── hello.xml
├── sample.log          (ignored)
└── log/
    └── error.txt
```

---

# Outcome

Successfully completed the following Git Hands-on Labs:

- Git Configuration
- Git Ignore
- Branching and Merging
- Merge Conflict Resolution
- Clean Up and Push to Remote Repository

---

## Author

**Name:** Roshni Singh

**Repository:** https://github.com/monu9523/cognizant
