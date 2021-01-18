# Описание на проекта
I.	Проектът е направен за цел потребителите да разгледат различни лекари на една болница, пациентите, лекарства и диагнозите.
Има authentication и authorization, както и две роли administrator и user, като админът има право да добави, редактира и изтрие данни, а  user само може да разгледа информациите.
Има и възможност за да разгледаме всичките данни на всяка таблица, която искаме, без да влизаме в някоя профил или без регистрация.

II.	Проектът съдържа три библиотеки: 
1)	DataStructure, която съдържа десет модела(класове):
a)	Класът Model, който е базов клас и всички други модели(класове) го наследяват.
b)	Класът Doctor, който съдържа информация за лекари.
c)	Класът Patient, който съдържа информация за пациенти.
d)	Класът Medicine, който съдържа информация за лекарства.
e)	Класът Room, който съдържа информация за стаите .
f)	Класът MedicalRecord, който съдържа информация за резултати от тестове.
g)	Класът PatientDoctor, който свързва клас Patient с Doctor за релация много към много.
h)  Класът PatientMedicine,който свързва клас Patient с Medicine за релация много към много.
i)  Класът User, който съдържа информация за потребитеите.
j)  Класът Role, който съдържа информация за ролите на потребителите.
Тази библиотека съдържа и DTOModels за всеки модел в отделни папки.
2)	DataAccess, която съдържа IRepositories и Repositories за всеки модел, класът exceptions за валидацията, migrations, ApplicationDbContext-а и един DbInitializer за ролите.
a)	ApplicationDbContext, наследява класът IdentityDbContext и съдържа връзка към всеки модел (клас).
3)	Hospital, която съдържа Service-и за всеки контролер,AutoMapper, който прави връзка между DTOModel-и и Model-те,осем контролера. Всички седем контролера наследяват базовият клас контролер и те са:
a)	DoctorController
b)	PatientController
c)	MedicineController
d)	RoomController
e)	MedicalRecordController
f)	PatientDoctorController
g)	PatientMedicineController
h)	UserController
