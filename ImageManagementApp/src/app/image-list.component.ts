import { Component, OnInit } from '@angular/core';
import { ImageService } from '../../services/image.service';
import { Image } from '../../models/image';

@Component({
    selector: 'app-image-list',
    templateUrl: './image-list.component.html',
    styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {
    images: Image[] = [];

    constructor(private imageService: ImageService) { }

    ngOnInit(): void {
        this.imageService.getImages().subscribe(data => {
            this.images = data;
        });
    }
}
