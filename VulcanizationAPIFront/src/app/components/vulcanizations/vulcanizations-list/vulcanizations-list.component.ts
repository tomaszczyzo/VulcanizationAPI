import { Component, OnInit } from '@angular/core';
import { Service } from '../../../Models/service.model';
import { Vulcanization } from '../../../Models/vulcanization.model';
import { VulcanizationsService } from '../../../services/vulcanizations.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ServicesListComponent } from '../../services/services-list/services-list.component';

@Component({
  selector: 'app-vulcanizations-list',
  templateUrl: './vulcanizations-list.component.html',
  styleUrls: ['./vulcanizations-list.component.css']
})
export class VulcanizationsListComponent implements OnInit {

  vulcanizations: Vulcanization[] = [];
  services: Service[] = [];

  constructor(private vulcanizationsService: VulcanizationsService, private dialog: MatDialog  ) { }
  
  ngOnInit(): void {
    this.vulcanizationsService.getAllVulcanizations()
      .subscribe({
        next: (vulcanizations) => {
          console.log(vulcanizations);
          this.vulcanizations = vulcanizations;
      },
        error: (response) => {
          console.log(response);
        }
      });
  }
  

  openDialog(idd: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "60%";
    dialogConfig.data =
    {
      id: idd
    };
    this.dialog.open(ServicesListComponent, dialogConfig);
}




}
