# SteampunkRochester
An investigative narrative based on the History of Rochester. Check out the development blog at http://rochester-steampunk.rhcloud.com

# Running a Ghost Blog

## Adding Users
1. Locate the Settings Tab
2. Open the Users section
3. Click the New User Button
4. Decide what permitions the new user should have.
    - Author
        Authors can only create new posts and edit their own posts.
    - Editor
        Editors can create and manage their own posts as well as anyone elses.
    - Admin
        Admins have access to all of the settings for the blog, as well as the ability to create and manage posts.
5. Type the email address of the user you would like to add.
6. Send the invitation.

## Navigation
Navigation can be created through custom themes, or in the settings for your blog.

# Creating Static Pages from a Ghost Blog for use on GitHub

## Instructions for Windows
1. pip install buster - buster is a tool that will brute force create static web pages
2. Download and install wget from [here](http://gnuwin32.sourceforge.net/packages/wget.htm). This is a dependency for buster.
3. In the folder you'd like to hold your static files, run buster setup <repo address>
4. If running the website locally
    - Run buster generate --domain=http://127.0.0.1:2368
5. Otherwise
    - Run buster generate --domain=yourdomainhere
6. Add these files to the GitHub pages repo or branch and commit them.

## Instructions for Mac
1. pip install buster - buster is a tool that will brute force create static web pages
2. brew install wget - this is a dependency for buster.
3. In the folder you'd like to hold your static files, run buster setup <repo address>
4. If running the website locally
    - Run buster generate --domain=http://127.0.0.1:2368
5. Otherwise
    - Run buster generate --domain=yourdomainhere
6. Add these files to the GitHub pages repo or branch and commit them.