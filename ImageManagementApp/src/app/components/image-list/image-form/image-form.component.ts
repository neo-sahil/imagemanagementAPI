import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ImageService } from '../../services/image.service';
import { Image } from '../../models/image';

@Component({
    selector: 'app-image-form',
    templateUrl: './image-form.component.html',
    styleUrls: ['./image-form.component.css']
})
export class ImageFormComponent implements OnInit {
    imageForm: FormGroup;

    constructor(private fb: FormBuilder, private imageService: ImageService) {
        this.imageForm = this.fb.group({
            user: ['', Validators.required],
            dateCreated: ['', Validators.required],
            description: ['', Validators.required],
            url: ['', [Validators.required, Validators.pattern('https?://.+')]]
        });
    }

    ngOnInit(): void { }

    onSubmit(): void {
        if (this.imageForm.valid) {
            const newImage: Image = this.imageForm.value;
            this.imageService.createImage(newImage).subscribe();
        }
    }
}
