This is not a fully workable application, with all the logic put down.
To use the app properly is needed to be registered and logged in.
After login user is redirected to `Complete Profile` page, where user chose his role.

If user is `ROLE_PATIENT` he will be redirected to `Patients` list(index) page, 
but if is `ROLE_DOCTOR` he will have to specify what doctor category is he
(dentist, therapist, ...). After that he will be redirected to `Doctor List`
page. 

On header bar is a button called `Menu`, it will trigger a dropdown, where will be 
`Doctor` and `Procedure` buttons, click on `Procedure`, go to `Create Procedure`  page and add a new procedure (add several procedures).

On header bar, click on `Menu` button, chose `Doctor` button, go to `Doctor List` page, chose your name (or desired name), on 
the lowest side of the page will be a section called `Select Procedure`, click on the link with procedure name you want to 
add to selected doctor, and procedure will be assigned to the doctor. There is no functionality to check if procedure was already 
assigned to the doctor, so, please do not break it (do not add the same procedure to the same doctor more times).
On the right side of the listed procedures will be shown procedures assigned to the doctor.

Go to home page '/', click on `Create new` button and select:
 - Procedure (All procedures can be selected)
 - Doctor (only doctor that have procedure assigned to him will be shown(ajax is used))
 - Select date
 - Select available time interval (in case interval is used, it will be shown as disabled with `(reserved)` label)
 
 
 Also on head bar is a button called `Admin`, you can do there and find registered procedures. Is possible to filter them
 by `Doctor`, `Procedure` and `Date` .
 
 