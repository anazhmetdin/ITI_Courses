import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  deleteStudent(Id: number) {
    return this._client.delete(`${this.URL}/${Id}`);
  }
  addStudent(student: any) {
    student["id"] = Math.ceil(Math.random() * 1000);
    return this._client.post(this.URL, student);
  }

  private readonly URL = "http://localhost:3000/Students";
  constructor(private _client: HttpClient) {}

  getAllStudents() {
    return this._client.get(this.URL);
  }

  getStudentById(id:number) {
    return this._client.get(`${this.URL}/${id}`);
  }

  updateStudent(id:number, student: any) {
    return this._client.put(`${this.URL}/${id}`, student);
  }
}
