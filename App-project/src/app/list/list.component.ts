import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.less']
})
export class ListComponent implements OnInit {

  public listPersons: any[] = [];
  public display = false;
  public displayDel = false;
  public personForm = new FormGroup({
    id: new FormControl(
      { value: 0, disabled: false }, Validators.compose([Validators.required])
    ),
    name_person: new FormControl(
      { value: '', disabled: false }, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(300)])
    ),
    cpf: new FormControl(
      { value: '', disabled: false }, Validators.compose([Validators.required, Validators.minLength(11)])
    ),
    age: new FormControl(
      { value: '', disabled: false }, Validators.compose([Validators.required, Validators.min(1), Validators.max(130)])
    ),
    name_city: new FormControl(
      { value: '', disabled: false }, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(200)])
    ),
    uf: new FormControl(
      { value: '', disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(2)])
    )
  });

  public states = [
    { name: 'Acre', code: 'AC' },
    { name: 'Alagoas', code: 'AL' },
    { name: 'Amazonas', code: 'AM' },
    { name: 'Amapá', code: 'AP' },
    { name: 'Bahia', code: 'BA' },
    { name: 'Ceará', code: 'CE' },
    { name: 'Distrito Federal', code: 'DF' },
    { name: 'Espírito Santo', code: 'ES' },
    { name: 'Goiás', code: 'GO' },
    { name: 'Maranhão', code: 'MA' },
    { name: 'Minas Gerais', code: 'MG' },
    { name: 'Mato Grosso do Sul', code: 'MS' },
    { name: 'Mato Grosso', code: 'MT' },
    { name: 'Pará', code: 'PA' },
    { name: 'Paraíba', code: 'PB' },
    { name: 'Pernambuco', code: 'PE' },
    { name: 'Piauí', code: 'PI' },
    { name: 'Paraná', code: 'PR' },
    { name: 'Rio de Janeiro', code: 'RJ' },
    { name: 'Rio Grande do Norte', code: 'RN' },
    { name: 'Rondônia', code: 'RO' },
    { name: 'Roraima', code: 'RR' },
    { name: 'Rio Grande do Sul', code: 'RS' },
    { name: 'Santa Catarina', code: 'SC' },
    { name: 'Sergipe', code: 'SE' },
    { name: 'São Paulo', code: 'SP' },
    { name: 'Tocantins', code: 'TO' }
  ];

  constructor(
    private sharedService: SharedService
  ) { }

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll() {
    this.sharedService.GetAll().subscribe(
      (response: any) => {
        this.listPersons = response.persons;
      },
      (error: any) => {
      }
    );
  }

  addUpdatePerson() {
    if (this.personForm.valid) {
      const body = {
        id: this.personForm.value.id,
        name_person: this.personForm.value.name_person,
        cpf: this.personForm.value.cpf.replace(/\D/g, ''),
        age: this.personForm.value.age,
        city: {
          name_city: this.personForm.value.name_city,
          uf: this.personForm.value.uf
        }
      }
      if (this.personForm.value.id === 0) {

        this.sharedService.Add(body).subscribe(
          (response: any) => {
            this.GetAll();
            this.display = false;
          },
          (error: any) => {
          }
        );
      } else {
        this.sharedService.Update(body.id, body).subscribe(
          (response: any) => {
            this.GetAll();
            this.display = false;
          },
          (error: any) => {
          });
      }
      this.personForm.reset();
    }
  }

  onConfirm(item: any) {
    this.displayDel = true;
    if (item) {
      this.personForm.setValue({
        id: item.id,
        name_person: item.name_person,
        cpf: item.cpf,
        age: item.age,
        name_city: item.city.name_city,
        uf: item.city.uf
      });
    }
  }

  deletePerson() {
    this.sharedService.Delete(this.personForm.value.id).subscribe(
      (response: any) => {
        this.GetAll();
        this.personForm.reset();
        this.displayDel = false;
      }
    );
  }

  openModal(item: any = null) {
    this.display = true;
    if (item) {
      this.personForm.setValue({
        id: item.id,
        name_person: item.name_person,
        cpf: item.cpf,
        age: item.age,
        name_city: item.city.name_city,
        uf: item.city.uf
      });
    } else {
      this.personForm.setValue({
        id: 0,
        name_person: '',
        cpf: '',
        age: '',
        name_city: '',
        uf: ''
      });
    }
  }

}
