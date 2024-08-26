import {
  Dialog,
  DialogPanel,
  DialogTitle,
  DialogBackdrop,
} from "@headlessui/react";

import { Course } from "../types";

interface CourseModalProps {
  course: Course;
  open: boolean;
  onClose: () => void;
}

function CourseModal({ course, open, onClose }: CourseModalProps) {
  return (
    <Dialog open={open} onClose={onClose} className="relative z-10">
      <DialogBackdrop
        transition
        className="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity data-[closed]:opacity-0 data-[enter]:duration-300 data-[leave]:duration-200 data-[enter]:ease-out data-[leave]:ease-in"
      />

      <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
        <div className="flex min-h-full items-end justify-center p-4 text-center items-center">
          <DialogPanel
            transition
            className="relative transform overflow-hidden rounded-lg bg-white text-left shadow-xl transition-all data-[closed]:translate-y-4 data-[closed]:opacity-0 data-[closed]:translate-y-0 data-[closed]:scale-95 data-[enter]:duration-300 data-[leave]:duration-200 data-[enter]:ease-out data-[leave]:ease-in my-8 w-full max-w-lg"
          >
            <div className="m-8 flex flex-col gap-4">
              <DialogTitle className="text-lg font-semibold leading-6 text-gray-900 flex gap-3">
                <div>{course.sectionID}</div>
                <div>{course.name}</div>
              </DialogTitle>
              <p className="text-base text-gray-500 indent-8">
                {course.description}
              </p>
            </div>
          </DialogPanel>
        </div>
      </div>
    </Dialog>
  );
}

export default CourseModal;
