import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Tarefa } from '../../../Tarefa';
import { CommonModule } from '@angular/common';
import { TaskItemComponent } from '../task-item/task-item.component';
import { AddTaskComponent } from '../add-task/add-task.component';
import { StatusEnum } from 'src/app/status/StatusEnum';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [CommonModule, TaskItemComponent, AddTaskComponent],
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  tarefas: Tarefa[] = [];

  constructor(private taskService:TaskService){}

  ngOnInit(): void {
    
    this.taskService.getTasks().subscribe((dado) => {
      this.tarefas = dado;
      console.log(dado);
    });
    
  }

  AddTask(tarefa: Tarefa){
    this.taskService.addTask(tarefa).subscribe((tarefa) => {
      this.tarefas.push(tarefa);
    });
  }

  deleteTask(tarefa: Tarefa){
      this.taskService.deleteTask(tarefa).subscribe(() =>
        (this.tarefas = this.tarefas.filter((t) => t.id !== tarefa.id)));
  }


  toggleConcluiido(tarefa: Tarefa){
    if(tarefa.status === StatusEnum.Concluido){
      tarefa.status = StatusEnum.Pendente
    }
    else{
      tarefa.status = StatusEnum.Concluido
    }
      
    this.taskService.updateTask(tarefa).subscribe();
  }

}
