import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Params } from '@angular/router';
import { Service } from '../../../Models/service.model';
import { ServicesService } from '../../../services/services.service';

@Component({
  selector: 'app-services-list',
  templateUrl: './services-list.component.html',
  styleUrls: ['./services-list.component.css']
})
export class ServicesListComponent implements OnInit {
  services: Service[] = [];
  id: number;
  constructor(private servicesService: ServicesService,
    private dialogRef: MatDialogRef<ServicesListComponent>,
    @Inject(MAT_DIALOG_DATA) data: any) { this.id = data.id; }

  ngOnInit() {
    this.servicesService.getAllServices(this.id)
      .subscribe({
        next: (services) => {
          console.log(services);
          this.services = services;
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  
  
  
}
