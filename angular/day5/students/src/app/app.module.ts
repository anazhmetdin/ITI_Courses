import { NgModule, createComponent } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/header/header.component';
import { studentFormComponent } from './Components/studentForm/studentForm.component';
import { StudentsComponent } from './Components/students/students.component';
import { DetailsComponent } from './Components/details/details.component';
import { ErrorComponent } from './Components/error/error.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UpdateComponent } from './Components/update/update.component';
import { CreateComponent } from './Components/create/create.component';
import { DeleteComponent } from './Components/delete/delete.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    studentFormComponent,
    StudentsComponent,
    DetailsComponent,
    ErrorComponent,
    UpdateComponent,
    CreateComponent,
    DeleteComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: StudentsComponent },
      { path: 'Register', component: CreateComponent },
      { path: 'Students/:Id', component: DetailsComponent },
      { path: 'Students/Update/:Id', component: UpdateComponent },
      { path: 'Students/Delete/:Id', component: DeleteComponent },
      { path: '**', component: ErrorComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
