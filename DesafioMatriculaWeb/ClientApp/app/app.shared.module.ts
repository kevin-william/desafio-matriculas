import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { MatriculaSemDVComponent } from './components/matriculaSemDV/matriculaSemDV.component';
import { MatriculaParaVerificarComponent } from './components/matriculaParaVerificar/matriculaParaVerificar.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,        
        HomeComponent,        
        MatriculaSemDVComponent,
        MatriculaParaVerificarComponent        
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },                        
            { path: 'matriculaSemDV', component: MatriculaSemDVComponent },
            { path: 'matriculaParaVerificar', component: MatriculaParaVerificarComponent },            
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
