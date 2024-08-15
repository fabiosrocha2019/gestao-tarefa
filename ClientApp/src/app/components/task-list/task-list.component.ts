import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { StatusEnum } from 'src/app/status/StatusEnum';
import { Tarefa } from 'src/Tarefa';

@Component({
  selector: 'app-task-list',
  standalone: true,
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
  imports: [CommonModule, FormsModule]
})
export class TaskListComponent implements OnInit {
  tarefas: Tarefa[] = [];  
  filteredTarefas: Tarefa[] = [];
  statusOptions: string[] = Object.values(StatusEnum);
  selectedStatus: string = '';

  ngOnInit(): void {
    this.filteredTarefas = this.tarefas;
  }

  filterTasks(): void {
    if (this.selectedStatus) {
      this.filteredTarefas = this.tarefas.filter(tarefa => tarefa.status === this.selectedStatus);
    } else {
      this.filteredTarefas = this.tarefas;
    }
  }

  deleteTask(tarefa: Tarefa): void {
    this.tarefas = this.tarefas.filter(t => t !== tarefa);
    this.filterTasks(); 
  }

  toggleConcluiido(tarefa: Tarefa): void {
    tarefa.status = tarefa.status === StatusEnum.Concluido ? StatusEnum.Pendente : StatusEnum.Concluido;
    this.filterTasks();  
  }
}