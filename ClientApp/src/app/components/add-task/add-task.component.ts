import { Component, Output,EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { Tarefa } from '../../../Tarefa';
import { ButtonComponent } from '../button/button.component';
import { CommonModule } from '@angular/common';
import { StatusEnum } from 'src/app/status/StatusEnum';

@Component({
  selector: 'app-add-task',
  standalone: true,
  imports: [FormsModule, ButtonComponent, CommonModule],
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent {
  @Output() onAddTask = new EventEmitter<Tarefa>();
  tarefa: any;
  titulo: string = '';
  descricao: string = '';
  dataVencimento: Date | undefined;
  status: StatusEnum = StatusEnum.Pendente;
  mostrarAddTarefa: boolean = false;

  AlteraVisualizacao(valor: boolean){
    this.mostrarAddTarefa = valor;
  }

  onSubmit(){
    if(!this.titulo) {
      alert('Adicione um título!')
      return;
    }

    if(!this.descricao) {
      alert('Adicione uma descrição!')
      return;
    }

    if(!this.dataVencimento) {
      alert('Adicione uma Data de Vencimento!')
      return;
    }

    const novaTarefa = {
      titulo: this.titulo,
      descricao: this.descricao,
      dataVencimento: this.dataVencimento,
      status: this.status
    }

    this.onAddTask.emit(novaTarefa);

    this.titulo = '';
    this.descricao = '';
    this.dataVencimento = undefined;
    this.status = StatusEnum.Pendente;

  }
}
