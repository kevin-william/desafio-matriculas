import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'matriculaParaVerificar',
    templateUrl: './matriculaParaVerificar.component.html'
})
export class MatriculaParaVerificarComponent{

    private baseUrl: string;
    public error: boolean;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.error = false;
    }

    public upload(files: File[]) {

        if (files.length === 0) return;

        let formData = new FormData();

        formData.append(files[0].name, files[0]);

        this.http
            .post(this.baseUrl + "api/Matricula/ValidarDigitosVerificadores", formData)
            .subscribe(response => {
                let link = document.createElement("a");
                link.href = URL.createObjectURL(new Blob([response.text()], { type: "application/octet-stream" }));
                link.download = "matriculasVerificadas.txt";
                link.click();
            }, error => this.error = true);
    }
}
