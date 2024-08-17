import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { StatusEnum } from 'src/app/status/StatusEnum';
import { Tarefa } from '../../../Tarefa';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'app-add-task',
  standalone: true,
  imports: [FormsModule, ButtonComponent, CommonModule],
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent {
  @Output() onAddTask = new EventEmitter<Tarefa>();
  titulo: string = '';
  descricao: string = '';
  dataVencimento: Date | undefined;
  status: StatusEnum = StatusEnum.Pendente;
  mostrarAddTarefa: boolean = false;

  statusOptions = Object.values(StatusEnum);

  AlteraVisualizacao(valor: boolean): void {
    this.mostrarAddTarefa = valor;
  }

  onSubmit(): void {
    if (!this.isValidInput()) {
      return;
    }

    const novaTarefa: Tarefa = {
      titulo: this.titulo,
      descricao: this.descricao,
      dataVencimento: this.dataVencimento!,
      status: this.status
    };

    this.onAddTask.emit(novaTarefa);

    this.resetForm();
  }

  private isValidInput(): boolean {
    if (this.titulo.trim().length === 0) {
      alert('Adicione um título!');
      return false;
    }

    if (this.descricao.trim().length === 0) {
      alert('Adicione uma descrição!');
      return false;
    }

    if (!this.dataVencimento) {
      alert('Adicione uma Data de Vencimento!');
      return false;
    }

    return true;
  }

  private resetForm(): void {
    this.titulo = '';
    this.descricao = '';
    this.dataVencimento = undefined;
    this.status = StatusEnum.Pendente;
  }
}